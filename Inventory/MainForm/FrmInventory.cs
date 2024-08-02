using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Inventory.Config;
using Inventory.PopupForm;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using Query = ServeAll.Core.Queries.Query;


namespace Inventory.MainForm
{
    public partial class FrmInventory : Form
    {

        private int _branchId;
        private string _branch;
        private readonly int _userId;
        private readonly int _usrTyp;

        private bool _extInvent;
        public bool ExiInven
        {
            get{ return _extInvent; }
            set
            {
                _extInvent = value; 
                if(_extInvent)
                Close();
               var main = new FirmMain(_userId, _usrTyp);
                main.Show();
            }
        }
        public int BranchId
        {
            get { return _branchId; }
            set
            {
                _branchId = value;
                
                 _branch   = GetBranchName(_branchId);
                cmbDIS.Text = _branch;
                BindProductList(_branch);
            }
        }
        public string DeliveryBranch
        {
            get { return _branch; }
            set
            {
                _branch = value;
                if (_branch.Length > 0)
                {
                    BindProductList(_branch);
                }
            }
        }

        private bool _add, _edt, _del;
        public FirmMain Main { get; set; }
        public FrmInventory(int userId, int usrTyp)
        {
            _userId = userId;
            _usrTyp = usrTyp;
            InitializeComponent();
        }
        private void FrmInventory_Load(object sender, EventArgs e)
        {
            var bra = new FirmPopInventoryBranch(_userId, _usrTyp)
            {
            };
            bra.ShowDialog();
           
        }
        private void bntADD_Click(object sender, EventArgs e)
        {
            ButAdd();
        }
        private void bntUPD_Click(object sender, EventArgs e)
        {
            ButUpd();
        }
        private void bntSAV_Click(object sender, EventArgs e)
        {
            ButSav();
        }
        private void bntCLR_Click(object sender, EventArgs e)
        {
            ButClr();
        }
        private void bntCAN_Click(object sender, EventArgs e)
        {
            ButCan();
        }
        private void bntDEL_Click(object sender, EventArgs e)
        {
            InputWhit();
            var que =
                PopupNotification.PopUpMessageQuestion(
                    "Are you sure you want to Delete Inventory: " + cmbNAM.Text.Trim(' ') + " " + "?", "Inventory Details");
            if (que)
            {
                ButDel();
            }
            else { ButCan(); }
        }
        private void bntHOM_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }
        private void pbHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }
        #region ButtonCRUD
        private void ButAdd()
        {
            ButtonAdd();
            InputEnab();
            InputWhit();
            InputClea();
            GenerateCode();
            BindProducts();
            BindBranch();
            BindProductStatus();
            cmbNAM.Focus();
            _add = true;
            _edt = false;
            _del = false;
            gCON.Enabled = false;
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
            cmbNAM.Size = new Size(422, 29);
        }
        private void ButtonAdd()
        {
            bntADD.Enabled = true;
            bntUPD.Enabled = false;
            bntDEL.Enabled = false;
            bntSAV.Enabled = true;
            bntCLR.Enabled = false;
            bntCAN.Enabled = true;
            bntHOM.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonUpd()
        {
            bntADD.Enabled = false;
            bntUPD.Enabled = true;
            bntDEL.Enabled = false;
            bntSAV.Enabled = true;
            bntCLR.Enabled = false;
            bntCAN.Enabled = true;
            bntHOM.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonDel()
        {
            bntADD.Enabled = false;
            bntUPD.Enabled = false;
            bntDEL.Enabled = true;
            bntSAV.Enabled = true;
            bntCLR.Enabled = false;
            bntCAN.Enabled = true;
            bntHOM.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonSav()
        {
            bntADD.Enabled = true;
            bntUPD.Enabled = true;
            bntDEL.Enabled = true;
            bntSAV.Enabled = false;
            bntCLR.Enabled = true;
            bntCAN.Enabled = false;
            bntHOM.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        private void ButtonClr()
        {
            bntADD.Enabled = true;
            bntUPD.Enabled = true;
            bntDEL.Enabled = true;
            bntSAV.Enabled = false;
            bntCLR.Enabled = false;
            bntCAN.Enabled = false;
            bntHOM.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        private void ButtonCan()
        {
            bntADD.Enabled = true;
            bntUPD.Enabled = true;
            bntDEL.Enabled = true;
            bntSAV.Enabled = false;
            bntCLR.Enabled = true;
            bntCAN.Enabled = false;
            bntHOM.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        private void ButUpd()
        {
            ButtonUpd();
            InputEnab();
            InputWhit();
            _add = false;
            _edt = true;
            _del = false;
            gCON.Enabled = false;
        }
        private void ButDel()
        {
            ButtonDel();
            InputEnab();
            InputWhit();
            _add = false;
            _edt = false;
            _del = true;
            gCON.Enabled = false;
        }
        private void ButClr()
        {
            ButtonClr();
            InputEnab();
            InputWhit();
            InputClea();
            gCON.Enabled = true;
           cmbNAM.DataBindings.Clear();
    
        }
        private void ButSav()
        {

            if (_add && _edt == false && _del == false)
            {
               
                DataInsert();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindProductList(_branch);
                
            }
            if (_add == false && _edt && _del == false)
            {
                 
                DataUpdate();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindProductList(_branch);
                 
            }
            if (_add == false && _edt == false && _del)
            {
                
                DataDelete();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindProductList(_branch);
                
            }
            _add = false;
            _edt = false;
            _del = false;
            gCON.Enabled = true;
            cmbNAM.DataBindings.Clear();
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
        }
        private void ButCan()
        {
            ButtonCan();
            InputDisb();
            InputDimG();
            InputClea();
            gCON.Enabled = true;
            cmbNAM.DataBindings.Clear();
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
        }
        #endregion
        
      
        private void BindProductList(string branchId)
        {
            gCON.Update();
            try
            {
                gCON.DataBindings.Clear();
                gCON.DataSource = null;
                gCON.DataSource = RebindInventory(branchId);
                if (gridInventory.RowCount > 0)
                {
                    gridInventory.Columns[0].Width = 40;
                    gridInventory.Columns[1].Width = 90;
                    gridInventory.Columns[2].Width = 280;
                    gridInventory.Columns[3].Width = 100;
                    gridInventory.Columns[3].Width = 120;

                }
            }
            catch (Exception ex)
            {
                gCON.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableSupplier);
            }
        }
        private void BindProducts()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Products>(unWork);
                var query = repository.SelectAll(Query.AllProducts).Select(x => x.product_name).Distinct().ToList();
                cmbNAM.DataBindings.Clear();
                cmbNAM.DataSource = query;
            }
        }
        private void BindBranch()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Branch>(unWork);
                var query = repository.SelectAll(Query.AllBranch).Select(x => x.branch_details).Distinct().ToList();
                cmbDIS.DataBindings.Clear();
                cmbDIS.DataSource = query;
            }
        }
        private void BindProductStatus()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<ProductStatus>(unWork);
                var query = repository.SelectAll(Query.AllProductStatus).Select(x => x.status).Distinct().ToList();
                cmbSAT.DataBindings.Clear();
                cmbSAT.DataSource = query;
            }
        }
        private static int GetProductId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Products>(unWork);
                    var query = repository.FindBy(x => x.product_name == input);
                    return query.product_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Product Id Error", "Inventory Details");
                    throw;
                }
            }
        }
       
        private static string GetBranchName(int branchId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Branch>(unWork);
                    var query = repository.FindBy(x => x.branch_id == branchId);
                    return query.branch_details;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Branch Id Error", "Inventory Details");
                    return null;
                }
            }
        }
        private static int GetBranchId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Branch>(unWork);
                    var query = repository.FindBy(x => x.branch_details == input);
                    return query.branch_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Branch Id Error", "Inventory Details");
                    throw;
                }
            }
        }
        private static int GetWarrantyId(string input)
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
        private static int GetProductStatus(string input)
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
        private static int GetProductImgId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewProductCategory>(unWork);
                    var query = repository.FindBy(x => x.product_name == input);
                    return query.image_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Image Id Error", "Product Details");
                    throw;
                }
            }
        }
        private static IEnumerable<ViewInventory> RebindInventory(string branch)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewInventory>(unWork);
                    return repository.SelectAll(Query.AllInventory)
                        .Where(x => x.branch_details == branch)
                        .ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleInventory);
                    throw;
                }
            }
        }
        private void InputWhit()
        {
            txtIND.BackColor = Color.White;
            txtICD.BackColor = Color.White;
            cmbNAM.BackColor = Color.White;
            txtDEL.BackColor = Color.White;
            txtQTY.BackColor = Color.White;
            cmbDIS.BackColor = Color.White;
            txtLST.BackColor = Color.White;
            txtORD.BackColor = Color.White;
            dkpDET.BackColor = Color.White;
            cmbSAT.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtIND.Enabled = true;
            txtICD.Enabled = true;
            cmbNAM.Enabled = true;
            txtDEL.Enabled = true;
            txtQTY.Enabled = true;
            cmbDIS.Enabled = true;
            txtLST.Enabled = true;
            txtORD.Enabled = true;
            dkpDET.Enabled = true;
            cmbSAT.Enabled = true;
        }
        private void InputDisb()
        {
            txtIND.Enabled = false;
            txtICD.Enabled = false;
            cmbNAM.Enabled = false;
            txtDEL.Enabled = false;
            txtQTY.Enabled = false;
            cmbDIS.Enabled = false;
            txtLST.Enabled = false;
            txtORD.Enabled = false;
            dkpDET.Enabled = false;
            cmbSAT.Enabled = false;
        }
        private void InputClea() {
            txtIND.Clear();
            txtICD.Clear();
            cmbNAM.Text = "";
            txtDEL.Clear();
            txtQTY.Clear();
            cmbDIS.Text = "";
            txtLST.Clear();
            txtORD.Clear();
            dkpDET.Value = DateTime.Now.Date;
            cmbSAT.Text = "";
        }
        private void InputDimG()
        {
            txtIND.BackColor = Color.DimGray;
            txtICD.BackColor = Color.DimGray;
            cmbNAM.BackColor = Color.DimGray;
            txtDEL.BackColor = Color.DimGray;
            txtQTY.BackColor = Color.DimGray;
            cmbDIS.BackColor = Color.DimGray;
            txtLST.BackColor = Color.DimGray;
            txtORD.BackColor = Color.DimGray;
            dkpDET.BackColor = Color.DimGray;
            cmbSAT.BackColor = Color.DimGray;
        }
       
        private void GenerateCode()
        {
            var lastProductId = FetchUtils.GetLastId();
            var alphaNumeric = new GenerateAlpaNum(3, 2, lastProductId, "PR");
            alphaNumeric.Increment();
            txtICD.Text = alphaNumeric.ToString();
        }
        private void DataInsert()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    posWET.ShowWaitForm();
                    var repository = new Repository<InventoryClass>(unWork);
                    var product = new InventoryClass()
                    {
                                                        inventory_code        = txtICD.Text,
                                                        product_id   = GetProductId(cmbNAM.Text),
                                                        delivery_code  = txtDEL.Text,
                                                        quantity    = Convert.ToInt32(txtQTY.Text),
                                                        branch_id    = GetBranchId(cmbDIS.Text),
                                                        last_price_cost    = Convert.ToDecimal(txtLST.Text),
                                                        inventory_date     = dkpDET.Value.Date,
                                                        status_id    = GetProductStatus(cmbSAT.Text)
                    };
                    var result = repository.Add(product);
                    if (result > 0)
                    {
                        posWET.CloseWaitForm();
                        PopupNotification.PopUpMessages(1, "Product Name: " + cmbNAM.Text.Trim(' ') + " " + Messages.SuccessInsert,
                         Messages.TitleSuccessInsert);
                        unWork.Commit();
                    }

                }
                catch (Exception ex)
                {
                    posWET.CloseWaitForm();
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFailedInsert);

                }
            }
        }
        private void DataUpdate()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    posWET.ShowWaitForm();
                    var proId           = Convert.ToInt32(txtIND.Text);
                    var repository      = new Repository<InventoryClass>(unWork);
                    var que             = repository.Id(proId);
                        que.inventory_code        = txtICD.Text;
                        que.product_id   = GetProductId(cmbNAM.Text);
                        que.delivery_code  = txtDEL.Text;
                        que.quantity    = Convert.ToDecimal(txtQTY.Text);
                        que.branch_id    = GetBranchId(cmbDIS.Text);
                        que.last_price_cost    = Convert.ToDecimal(txtLST.Text);
                        que.inventory_date     = dkpDET.Value.Date;
                        que.status_id    = GetProductStatus(cmbSAT.Text);
                        var result      = repository.Update(que);
                    if (result)
                    {
                        posWET.CloseWaitForm();
                        PopupNotification.PopUpMessages(1,
                            "Product Name: " + cmbNAM.Text.Trim(' ') + " " + Messages.SuccessUpdate,
                            Messages.TitleSuccessUpdate);
                        unWork.Commit();
                    }
                    else
                    {
                        posWET.CloseWaitForm();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedUpdate);

                }
            }
        }
        private void DataDelete()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    posWET.ShowWaitForm();
                    var proId = Convert.ToInt32(txtIND.Text);
                    var repository = new Repository<InventoryClass>(unWork);
                    var que = repository.Id(proId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        posWET.CloseWaitForm();
                        PopupNotification.PopUpMessages(1,
                            "Product Name: " + cmbNAM.Text.Trim(' ') + " " + Messages.SuccessDelete,
                            Messages.TitleSuccessDelete);
                        unWork.Commit();
                    }
                    else
                    {
                        posWET.CloseWaitForm();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedDelete);

                }
            }
        }
        private void cmbNAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNAM.Text.Length <= 0) return;
            var imgId = GetProductImgId(cmbNAM.Text);
         
        }
        private void gridInventory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridInventory.RowCount <= 0) return;
            try
            {
                var invId = (int)((GridView)sender).GetFocusedRowCellValue("InventoryId");
                ShowValue(invId);
 
                txtBAR.Text = SearchBarcode(cmbNAM.Text).product_code;
                lblPRZ.Text = SearchBarcode(cmbNAM.Text).retail_price.ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void ShowValue(int inventoryId)
        {
            var ent = ShowEntity(inventoryId);
            txtIND.Text = ent.inventory_id.ToString();
            txtICD.Text = ent.inventory_code;
            cmbNAM.Text = ent.product_name;
            txtDEL.Text = ent.delivery_code;
            txtQTY.Text = ent.quantity.ToString(CultureInfo.InvariantCulture);
            cmbDIS.Text = ent.branch_details;
            txtLST.Text = ent.retail_price.ToString(CultureInfo.InvariantCulture);
            txtORD.Text = ent.on_order.ToString();
            dkpDET.Value = ent.inventory_date;
            cmbSAT.Text = ent.status;
        }
        private static ViewInventory ShowEntity(int inventoryId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewInventory>(unWork);
                    var query = repository.FindBy(x => x.inventory_id == inventoryId);
                    return query;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        }
        private void gridInventory_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhit();
        }
        private void gridInventory_LostFocus(object sender, EventArgs e)
        {
            InputDimG();
        }
        //Verify Numeric
        private void txtLST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtLST.Focus();
                txtLST.BackColor = Color.Yellow;
            }
            else
            {
                txtLST.BackColor = Color.White;
            }
        }
        private void cmbSAT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void pbExit_Click(object sender, EventArgs e)
        {
            PopupNotification.PopUpMessageExit();
        }
        private void txtORD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtORD.Focus();
                txtORD.BackColor = Color.Yellow;
            }
            else
            {
                txtORD.BackColor = Color.White;
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
        private void cmbNAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var len = cmbNAM.Text.Length;
            if (len > 0)
            {
                cmbNAM.BackColor = Color.White;
                txtDEL.BackColor = Color.Yellow;
                txtDEL.Focus();
                  
                txtBAR.Text = SearchBarcode(cmbNAM.Text).product_code;
                lblPRZ.Text = SearchBarcode(cmbNAM.Text).retail_price.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                PopupNotification.PopUpMessages(0, "Product Name in inventory must not be empty!", Messages.GasulPos);
                cmbNAM.BackColor = Color.Yellow;
                cmbNAM.Focus();
            }
        }
        private void txtDEL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtDEL, txtQTY, "Inventory Delivery No.",
                Messages.TitleInventory);
            }
        }
        private void txtQTY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var len = txtQTY.Text.Length;
            if (len > 0)
            {
                txtQTY.BackColor = Color.White;
                cmbDIS.BackColor = Color.Yellow;
                cmbDIS.Focus();
            }
            else
            {
                txtQTY.Text = @"0";
                txtQTY.BackColor = Color.White;
                cmbDIS.BackColor = Color.Yellow;
                cmbDIS.Focus();
            }
        }
        private void cmbDIS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputCaseLeave(cmbDIS, txtLST, "Branch Name",
                Messages.TitleInventory);
            }
            if (e.KeyCode == Keys.F1)
            {
                BindBranch();
            }
        }
        private void txtLST_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var len = txtLST.Text.Length;
            if (len > 0)
            {
                txtLST.BackColor = Color.White;
                txtORD.BackColor = Color.Yellow;
                txtORD.Focus();
            }
            else
            {
                txtLST.Text = @"0";
                txtLST.BackColor = Color.White;
                txtORD.BackColor = Color.Yellow;
                txtORD.Focus();
            }
        }
        private void txtORD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var len = txtORD.Text.Length;
            if (len > 0)
            {
                txtORD.BackColor = Color.White;
                dkpDET.Focus();
            }
            else
            {
                txtORD.Text = @"0";
                txtORD.BackColor = Color.White;
                dkpDET.Focus();
            }
        }
        private void GbPersonal_Paint(object sender, PaintEventArgs e)
        {

        }
        private void cmbNAM_Leave(object sender, EventArgs e)
        {
            cmbNAM.Size = new Size(269, 29);
            if (txtBAR.Text.Length != 0) return;
            txtBAR.Text = SearchBarcode(cmbNAM.Text).product_code;
            lblPRZ.Text = SearchBarcode(cmbNAM.Text).retail_price.ToString(CultureInfo.InvariantCulture);
        }
        private void dkpDET_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            cmbSAT.Focus();
        }
        private void cmbNAM_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbNAM.Size = new Size(422, 29);
        }
        private void cmbSAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                BindProductStatus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputCaseLeave(cmbSAT, txtBAR, "Product Status",
                Messages.TitleInventory);
            }
        }
        private static Products SearchBarcode(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Products>(unWork);
                    var query = repository.FindBy(x => x.product_name == input);
                    return query;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Product entity Error", "Inventory Details");
                    throw;
                }
            }
        }
    }
}
