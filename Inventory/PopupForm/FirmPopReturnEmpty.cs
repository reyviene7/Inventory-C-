using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Inventory.Config;
using Inventory.MainForm;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using Query = ServeAll.Core.Queries.Query;

namespace Inventory.PopupForm
{
    public partial class FirmPopReturnEmpty : Form
    {
        public string RetCode { get; set; }
        public FirmWareHouseReturn Main { get; set; }
        private readonly int _productId;
        private readonly int _inventoId;
        private readonly string _origin;
        private readonly string _destin;
        private readonly string _prodct;
        public FirmPopReturnEmpty(int productId, int inventoId, string origin, string destin, string prodct)
        {
            _productId = productId;
            _inventoId = inventoId;
            _origin = origin;
            _destin = destin;
            _prodct = prodct;
            InitializeComponent();
        }
        private void FirmPopReturnEmpty_Load(object sender, EventArgs e)
        {
            txtINV.Text = _inventoId.ToString();
            txtORG.Text = _origin;
            cmbBRA.Text = _destin;
            BindProducts();
        }
        private void ShowEntity(string name)
        {
            var entity = Entity(name);
            txtPID.Text = entity.product_id.ToString();
        }
        private Products Entity(string name)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Products>(unWork);
                    return repository.FindBy(x => x.product_name == name);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
               
                 
            }
        }
        private void bntCAN_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void bntSVA_Click(object sender, EventArgs e)
        {
            ReturnLpg();
            Close();
        }
        private void txtRET_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtRET.Text.Length;
                var value = string.Format(txtRET.Text).ToUpper();
                if (len > 0)
                {
                    txtQTY.BackColor = Color.Yellow;
                    txtRET.BackColor = Color.White;
                    txtRET.Text = value;
                    txtQTY.Focus();
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Return No must not be empty!", Messages.GasulPos);
                    txtRET.BackColor = Color.Yellow;
                    txtRET.Focus();
                }
            }

        }
        private void txtRET_Leave(object sender, EventArgs e)
        {
            var len = txtRET.Text.Length;
            var value = txtRET.Text.Trim(' ');
            if (len > 0)
            {
                var verify = VerifyReturnNo(value);
                if (verify > 0)
                {
                    PopupNotification.PopUpMessages(0, "Return No: " + value + " already exist!", Messages.GasulPos);
                    txtRET.BackColor = Color.Yellow;
                    txtRET.Focus();
                }
            }
        }
        private void txtQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtQTY.Focus();
                txtQTY.BackColor = Color.Yellow;
            }
            else
            {
                txtQTY.BackColor = Color.White;
            }
        }
        private void txtQTY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtQTY.Text.Length;
                if (len > 0)
                {
                    txtQTY.BackColor = Color.White;
                    dkpDEL.Focus();
                }
                else
                {
                    txtQTY.Text = Constant.DefaultZero.ToString();
                }
            }
        }
        private void dkpDEL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dkpDET.Focus();
            }
        }
        private void dkpDET_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMAR.Focus();
            }
        }
        private void txtMAR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtMAR.Text.Length;
                if (len > 0)
                {
                    bntSVA.Focus();
                }
                else
                {
                    txtMAR.Text = Constant.DefaultNone;
                    bntSVA.Focus();
                }
            }
        }
        private void ReturnLpg()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var item = new ReturnWareHouse
                    {
                        ReturnCode      = GenerateReturn(),
                        ProductId       = int.Parse(txtPID.Text),
                        ReturnNo        = txtRET.Text.Trim(' '),
                        ReturnQty       = decimal.Parse(txtQTY.Text),
                        BranchId        = GetBranchId(_origin),
                        Destination     = GetBranchId(_destin),
                        ReturnDelivery  = dkpDEL.Value.Date,
                        RefDate         = dkpDET.Value.Date,
                        StatusId        = GetProductStatus(cmbSAT.Text),
                        Remarks         = txtMAR.Text.Trim(' '),
                        InventoryId     = _inventoId
                    };
                    retWET.ShowWaitForm();
                    unWork.Begin();
                    var repository = new Repository<ReturnWareHouse>(unWork);
                    var result = repository.Add(item);
                    if (result > 0)
                    {
                        retWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Return Delivery No: " + txtRET.Text.Trim(' ') + " successfully return to Warehouse!", Messages.GasulPos);
                    }
                    else
                    {
                        retWET.CloseWaitForm();
                        unWork.Rollback();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
        private string GenerateReturn()
        {
            var lastCode = GetLastReturnId();
            var lastId = GetSettings.GetLastBarcode(lastCode);
            var alphaNumeric = new GenerateAlpaNum(3, 2, lastId, "D");
            alphaNumeric.Increment();
            return alphaNumeric.ToString();
        }
        private string GetLastReturnId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<ViewReturnWarehouse>(unitWork);
                var result = (from b in repository.SelectAll(ServeAll.Core.Queries.Query.SelectAllReturnWareHs)
                              orderby b.return_id descending
                              select b.return_code).Take(1).SingleOrDefault();
                if (result != null)
                {
                    return result;
                }
                result = Query.DefaultCode;
                return result;
            }
        }
        private int GetBranchId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Branch>(unWork);
                    var query = repository.FindBy(x => x.BranchDetails == input);
                    return query.branch_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Branch Id Error", "Inventory Details");
                    throw;
                }
            }
        }
        private int GetProductStatus(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ProductStatus>(unWork);
                    var query = repository.FindBy(x => x.status == input);
                    return query.status_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Product Status Id Error", "Inventory Details");
                    throw;
                }
            }
        }
        private int VerifyReturnNo(string returnNo)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReturnWarehouse>(unWork);
                    return repository.SelectAll(Query.SelectCountReturnNo)
                        .Where(x => x.return_number == returnNo)
                        .Select(x => x.return_id)
                        .Count();
                }
                catch (Exception e)
                {
                    Console.Write(e.ToString());
                    return 0;
                }
            }
        }
        private void BindProducts()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Products>(unWork);
                var query = repository.SelectAll(Query.AllProducts)
                    .Where(x => x.product_name.Contains(Constant.DefaultEmptyCylinder))
                    .Select(x => x.product_name)
                    .Distinct().ToList();
                cmbNAM.DataBindings.Clear();
                cmbNAM.DataSource = query;
            }
        }
        private void cmbNAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = cmbNAM.Text.Length;
                if (len > 0)
                {
                    var value = cmbNAM.Text.Trim(' ');
                    ShowEntity(value);
                    txtRET.BackColor = Color.Yellow;
                    txtRET.Focus();
                }
            }
            else
            {
                PopupNotification.PopUpMessages(0, "Product Name must not be empty!", Messages.GasulPos);
                cmbNAM.Focus();
            }
        }
    }
}
