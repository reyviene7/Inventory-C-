using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Inventory.Config;
using Inventory.MainForm;
 
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using Query = ServeAll.Core.Queries.Query;

namespace Inventory.PopupForm
{
    public partial class FirmPopDeliveryInvBranch : Form
    {
        public FirmWarehouse Main { protected get; set; }
        private readonly int     _userId;
        private readonly int     _userTy;
        private readonly int     _wrhoId;
        private readonly string  _wrhoCd;
        private readonly decimal _lstCst;
        private readonly int     _prcdId;
        private readonly string  _prcdNm;
        private readonly string  _prcCod;
        private readonly decimal _werQty;
        private readonly int     _onOrdr;
     
       
        public FirmPopDeliveryInvBranch(int userId, int userTy, int wrhoId, string wrhoCd, decimal lstCst, int prcdId, string prcdNm, string prcCod, decimal werQty, int onOrdr )
        {
            _userId = userId;
            _userTy = userTy;
            _wrhoId = wrhoId;
            _wrhoCd = wrhoCd;
            _lstCst = lstCst;
            _prcdId = prcdId;
            _prcdNm = prcdNm;
            _prcCod = prcCod;
            _werQty = werQty;
            _onOrdr = onOrdr;
            InitializeComponent();
        }
        private void FirmPopDeliveryInvBranch_Load(object sender, EventArgs e)
        {
            txtWID.Text = _wrhoId.ToString();
            txtCOD.Text = _wrhoCd;
            txtLST.Text = _lstCst.ToString(CultureInfo.InvariantCulture);
            txtPID.Text = _prcdId.ToString();
            txtNAM.Text = _prcdNm;
            txtPOD.Text = _prcCod;
            txtWQY.Text = _werQty.ToString(CultureInfo.InvariantCulture);
            txtORD.Text = _onOrdr.ToString();
            BindBranch();
            BindStatus();
            BindWarranty();
        }
        private void bntSVA_Click(object sender, EventArgs e)
        {
            if (_userId != 0 && _userTy != 3)
            {
                InsertDeliveryBranch();
                Main.Deliver = 1;
                Close();
            }
        }

        private void InsertDeliveryBranch()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    delWET.ShowWaitForm();
                    var branchDel = new BranchDelivery
                    {
                         Code           = txtCOD.Text.Trim(' '), 
                         ProductId      = _prcdId,
                         WareHouseId    = _wrhoId,
                         QtyStock       = decimal.Parse(txtQTY.Text),
                         DeliveryNo     = txtDEC.Text.Trim(' '),
                         ReceiptNo      = txtREC.Text.Trim(' '),
                         BranchId       = GetBranchId(cmbDIS.Text), 
                         LastCost       = _lstCst, 
                         OnOrder        = _onOrdr, 
                         WarrantyId     = GetWarrantyId(cmbWAR.Text),
                         StatusId       = GetProductStatus(cmbSAT.Text), 
                         DeliveryDate   = dkpDEL.Value.Date
                    };
                    var quantity = txtQTY.Text.Trim(' ');
                    var product = txtNAM.Text.Trim(' ');
                    var branch = cmbDIS.Text.Trim(' ');
                    unWork.Begin();
                    var repository = new Repository<BranchDelivery>(unWork);
                    var result = repository.Add(branchDel);
                    if (result > 0)
                    {
                        delWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Item Name: "+product+ " with quantity "+quantity+" successfully delivered to branch "+branch, Messages.GasulPos);
                        Close();
                    }
                }
                catch (Exception e)
                {
                    unWork.Rollback();
                   Console.WriteLine(e.ToString());
                }
            }
        }

 

        private int GetProductId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Products>(unWork);
                    var query = repository.FindBy(x => x.Name == input);
                    return query.ProductId;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Product Id Error", "Inventory Details");
                    return 0;
                }
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
                    return query.BranchId;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Branch Id Error", "Inventory Details");
                    throw;
                }
            }
        }
        private int GetWarrantyId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Warranty>(unWork);
                    var query = repository.FindBy(x => x.Name == input);
                    return query.WarrantyId;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Warranty Id Error", "Product Details");
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
                    var query = repository.FindBy(x => x.Status == input);
                    return query.StatusId;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Product Status Id Error", "Inventory Details");
                    throw;
                }
            }
        }
        private void BindBranch()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Branch>(unWork);
                var query = repository.SelectAll(Query.AllBranch).Select(x => x.BranchDetails).Distinct().ToList();
                cmbDIS.DataBindings.Clear();
                cmbDIS.DataSource = query;
            }
        }
        private void BindStatus()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<ProductStatus>(unWork);
                var query = repository.SelectAll(Query.AllProductStatus).Select(x => x.Status).Distinct().ToList();
                cmbSAT.DataBindings.Clear();
                cmbSAT.DataSource = query;
            }
        }
        private void BindWarranty()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Warranty>(unWork);
                var query = repository.SelectAll(Query.AllWarranty).Select(x => x.Name).Distinct().ToList();
                cmbWAR.DataBindings.Clear();
                cmbWAR.DataSource = query;
            }
        }
        private int VerifyDelNo(string deliveryNo)
        {
            using (var session = new DalSession())
            {
                try
                {
                    var unWork = session.UnitofWrk;
                    var repository = new Repository<ServeAll.Core.Entities.Inventory>(unWork);
                    return repository.SelectAll(Query.AllInventory)
                        .Where(x => x.DeliveryNo == deliveryNo)
                        .Select(x => x.InventoryId)
                        .Count();
                }
                catch (Exception)
                {
                    return 0;
                }

            }
        }
        private int VerifyReceiptNo(string receiptNo)
        {
            using (var session = new DalSession())
            {
                try
                {
                    var unWork = session.UnitofWrk;
                    var repository = new Repository<ServeAll.Core.Entities.Inventory>(unWork);
                    return repository.SelectAll(Query.AllInventory)
                        .Where(x => x.ReceiptNo == receiptNo)
                        .Select(x => x.InventoryId)
                        .Count();
                }
                catch (Exception)
                {
                    return 0;
                }

            }
        }
        private void bntCAN_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtDEC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtDEC.Text.Length;
                if (len > 0)
                {
                    var capz = string.Format(txtDEC.Text).ToUpper();
                    txtDEC.BackColor = Color.White;
                    txtDEC.Text = capz;
                    txtREC.Focus();
                    txtREC.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Delivery Number must not be empty!", Messages.GasulPos);
                    txtDEC.Focus();
                    txtDEC.BackColor = Color.Yellow;
                }
            }
        }

        private void txtREC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtREC.Text.Length;
                if (len > 0)
                {
                    var capz = string.Format(txtREC.Text).ToUpper();
                    txtREC.BackColor = Color.White;
                    txtREC.Text = capz;
                    cmbDIS.Focus();
                    cmbDIS.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Receipt Number must not be empty!", Messages.GasulPos);
                    txtREC.Focus();
                    txtREC.BackColor = Color.Yellow;
                }
            }
        }

        private void txtQTY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtQTY.Text.Length;
                if (len > 0)
                {
                    var wareHouseQty = decimal.Parse(txtWQY.Text);
                    var deliveryQtys = decimal.Parse(txtQTY.Text);
                    if (deliveryQtys > wareHouseQty)
                    {
                        PopupNotification.PopUpMessages(0,
                            "The delivery Quantity must not be greater than quantity available in Warehouse!",
                            Messages.GasulPos);
                        txtQTY.Clear();
                        txtQTY.Focus();
                        txtQTY.BackColor = Color.Yellow;
                    }
                    else
                    {
                        var total = wareHouseQty - deliveryQtys;
                        txtWQY.Text = total.ToString(CultureInfo.InvariantCulture);
                        txtQTY.BackColor = Color.White;
                        dkpDEL.Focus();
                        dkpDEL.BackColor = Color.Yellow;
                    }
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Receipt Number must not be empty!", Messages.GasulPos);
                    txtQTY.Focus();
                    txtQTY.BackColor = Color.Yellow;
                }
            }
        }

        private void txtWQY_Leave(object sender, EventArgs e)
        {
            var len = txtQTY.Text.Length;
            if (len > 0)
            {
                var wareHouseQty = decimal.Parse(txtWQY.Text);
                var deliveryQtys = decimal.Parse(txtQTY.Text);
                if (deliveryQtys > wareHouseQty)
                {
                    PopupNotification.PopUpMessages(0,
                        "The delivery Quantity must not be greater than quantity available in Warehouse!",
                        Messages.GasulPos);
                    txtQTY.Clear();
                    txtQTY.Focus();
                    txtQTY.BackColor = Color.Yellow;
                }
                else
                {
                    var total = wareHouseQty - deliveryQtys;
                    txtWQY.Text = total.ToString(CultureInfo.InvariantCulture);
                    txtQTY.BackColor = Color.White;
                    dkpDEL.Focus();
                    dkpDEL.BackColor = Color.Yellow;
                }
            }
            else
            {
                PopupNotification.PopUpMessages(0, "Receipt Number must not be empty!", Messages.GasulPos);
                txtQTY.Focus();
                txtQTY.BackColor = Color.Yellow;
            }
        }

        private void txtWQY_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dkpDEL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dkpDET.Focus();
        }

        private void dkpDET_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbSAT.BackColor=Color.Yellow;
                cmbSAT.Focus();
            }
        }

        private void cmbSAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = cmbSAT.Text.Length;
                if (len > 0)
                {
                    cmbSAT.BackColor = Color.White;
                    cmbWAR.BackColor = Color.Yellow;
                    cmbWAR.Focus();
                }
                else
                {
                    cmbSAT.Text = Constant.DefaultDelivery;
                    cmbSAT.BackColor = Color.White;
                    cmbWAR.BackColor = Color.Yellow;
                    cmbWAR.Focus();
                }
            }
        }

        private void cmbWAR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                var len = cmbWAR.Text.Length;
                if (len > 0)
                {
                    cmbWAR.BackColor = Color.White;
                    bntSVA.Focus();
                }
                else
                {
                    cmbWAR.Text = Constant.DefaultWarranty;
                    cmbWAR.BackColor = Color.White;
                    bntSVA.Focus();
                }
            }
        }

        private void cmbDIS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = cmbDIS.Text.Length;
                if (len > 0)
                {
                    cmbDIS.BackColor = Color.White;
                    txtQTY.Focus();
                    txtQTY.BackColor = Color.Yellow;
                }
                else
                {
                    cmbDIS.BackColor = Color.White;
                    cmbDIS.Text = Constant.DefaultBranch;
                    txtQTY.Focus();
                    txtQTY.BackColor = Color.Yellow;
                }
            }
        }

        private void txtREC_Leave(object sender, EventArgs e)
        {
            var len = txtREC.Text.Length;
            var receipt = txtREC.Text.Trim(' ');
            if (len > 0)
            {
                var verify = VerifyReceiptNo(receipt);
                if (verify > 0)
                {
                    PopupNotification.PopUpMessages(0, "Receipt No: "+receipt+" already exist in Inventory!", Messages.GasulPos);
                    txtREC.BackColor = Color.Yellow;
                    cmbDIS.BackColor = Color.White;
                    txtREC.Focus();
                }
            }
        }

        private void txtDEC_Leave(object sender, EventArgs e)
        {
            var len = txtDEC.Text.Length;
            var delivery = txtDEC.Text.Trim(' ');
            if (len > 0)
            {
                var verify = VerifyDelNo(delivery);
                if (verify > 0)
                {
                    PopupNotification.PopUpMessages(0, "Delivery No: " + delivery + " already exist in Inventory!", Messages.GasulPos);
                    txtDEC.BackColor = Color.Yellow;
                    txtREC.BackColor = Color.White;
                    txtDEC.Focus();
                }
            }
        }
    }
}
