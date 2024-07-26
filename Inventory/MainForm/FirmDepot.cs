using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Inventory.Config;
using Inventory.Entities;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using Query = ServeAll.Core.Queries.Query;

namespace Inventory.MainForm
{
    public partial class FirmDepot : Form
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
                BindDepotList();
            }
        }
        private bool _add, _edt, _del;
        public FirmMain Main { get; set; }
        public FirmDepot(int userId, int usrTyp)
        {
            _userId = userId;
            _usrTyp = usrTyp;
            InitializeComponent();
        }
        private void FrmInventory_Load(object sender, EventArgs e)
        {
            BindDepotList();
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
            BindProductWarranty();
            cmbNAM.Focus();
            _add = true;
            _edt = false;
            _del = false;
            gCON.Enabled = false;
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
            cmbNAM.Size = new Size(422, 29);
            txtDEL.Text = GetLastDeliveryNo();
            txtREC.Text = GetLastDeliveryNo();
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
                BindDepotList();
                
            }
            if (_add == false && _edt && _del == false)
            {
              
                DataUpdate();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindDepotList();
            
            }
            if (_add == false && _edt == false && _del)
            {
              
                DataDelete();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindDepotList();
             
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
        private void DisplayImage(int imgId)
        {

            imgPRO.DataBindings.Clear();
            var img = GetByImage(imgId);
            if (img != null)
            {
                MemoryStream memoryStream = new MemoryStream(img);
                imgPRO.Image = Image.FromStream(memoryStream);
             
            }
            else
            {

                imgPRO.Image = null;
            }
        }
        private void BindDepotList()
        {
            gCON.Update();
            var refDate = DateTime.Now.Date;
                gCON.DataBindings.Clear();
                gCON.DataSource = null;
                gCON.DataSource = RebindInventory(refDate);
            if (gridInventory.RowCount <= 0) return;
                gridInventory.Columns[0].Width = 40;
                gridInventory.Columns[1].Width = 90;
                gridInventory.Columns[2].Width = 280;
                gridInventory.Columns[3].Width = 100;
                gridInventory.Columns[3].Width = 120;
        }
        private void BindProducts()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Products>(unWork);
                var query = repository.SelectAll(Query.AllProducts)
                    .Where(x => x.Name.Contains(Constant.AddFilterLpg))
                    .Select(x => x.Name)
                    .Distinct()
                    .ToList();
                cmbNAM.DataBindings.Clear();
                cmbNAM.DataSource = query;
            }
        }
        private void BindBranch()
        {
            cmbDIS.Text = Constant.DefaultWareHouse;
        }
        private void BindProductStatus()
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
        private void BindProductWarranty()
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
        private void InputWhit()
        {
            txtIND.BackColor = Color.White;
            txtICD.BackColor = Color.White;
            cmbNAM.BackColor = Color.White;
            txtDEL.BackColor = Color.White;
            txtREC.BackColor = Color.White;
            txtQTY.BackColor = Color.White;
            cmbDIS.BackColor = Color.White;
            cmbWAR.BackColor = Color.White;
            txtLST.BackColor = Color.White;
            txtORD.BackColor = Color.White;
            dkpPUR.BackColor = Color.White;
            dkpDET.BackColor = Color.White;
            cmbSAT.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtIND.Enabled = true;
            txtICD.Enabled = true;
            cmbNAM.Enabled = true;
            txtDEL.Enabled = true;
            txtREC.Enabled = true;
            txtQTY.Enabled = true;
            cmbDIS.Enabled = true;
            cmbWAR.Enabled = true;
            txtLST.Enabled = true;
            txtORD.Enabled = true;
            dkpPUR.Enabled = true;
            dkpDET.Enabled = true;
            cmbSAT.Enabled = true;
        }
        private void InputDisb()
        {
            txtIND.Enabled = false;
            txtICD.Enabled = false;
            cmbNAM.Enabled = false;
            txtDEL.Enabled = false;
            txtREC.Enabled = false;
            txtQTY.Enabled = false;
            cmbDIS.Enabled = false;
            cmbWAR.Enabled = false;
            txtLST.Enabled = false;
            txtORD.Enabled = false;
            dkpPUR.Enabled = false;
            dkpDET.Enabled = false;
            cmbSAT.Enabled = false;
        }
        private void InputClea() {
            
            txtIND.Clear();
            txtICD.Clear();
            cmbNAM.Text = "";
            cmbDIS.Text = "";
            cmbWAR.Text = @"NO WARRANTY";
            txtLST.Clear();
            txtORD.Clear();
            dkpPUR.Value = DateTime.Now.Date;
            dkpDET.Value = DateTime.Now.Date;
            cmbSAT.Text = "";
            if(_add)return;
            txtDEL.Clear();
            txtREC.Clear();
        }
        private void InputDimG()
        {
            txtIND.BackColor = Color.DimGray;
            txtICD.BackColor = Color.DimGray;
            cmbNAM.BackColor = Color.DimGray;
            txtDEL.BackColor = Color.DimGray;
            txtREC.BackColor = Color.DimGray;
            txtQTY.BackColor = Color.DimGray;
            cmbDIS.BackColor = Color.DimGray;
            cmbWAR.BackColor = Color.DimGray;
            txtLST.BackColor = Color.DimGray;
            txtORD.BackColor = Color.DimGray;
            dkpPUR.BackColor = Color.DimGray;
            dkpDET.BackColor = Color.DimGray;
            cmbSAT.BackColor = Color.DimGray;
        }
        private void GenerateCode()
        {
            var lastCode = GetLastCode();
            var lastId = GetSettings.GetLastBarcode(lastCode);
            var alphaNumeric = new GenerateAlpaNum(3, 2, lastId, "D");
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
                  
                    var repository = new Repository<Depot>(unWork);
                    var product = new Depot()
                    {
                        Code        = txtICD.Text,
                        ProductId   = GetProductId(cmbNAM.Text),
                        DeliveryNo  = txtDEL.Text,
                        ReceiptNo   = txtREC.Text,
                        QtyStock    = Convert.ToInt32(txtQTY.Text),
                        BranchId    = GetBranchId(cmbDIS.Text),
                        LastCost    = Convert.ToDecimal(txtLST.Text),
                        OnOrder     = Convert.ToInt32(txtORD.Text),
                        PurDate     = dkpPUR.Value.Date,
                        InvDate     = dkpDET.Value.Date,
                        WarrantyId  = GetWarrantyId(cmbWAR.Text),
                        StatusId    = GetProductStatus(cmbSAT.Text)
                    };
                    var result = repository.Add(product);
                    if (result > 0)
                    {
                      
                        PopupNotification.PopUpMessages(1, "Product Name: " + cmbNAM.Text.Trim(' ') + " " + Messages.SuccessInsert,
                         Messages.TitleSuccessInsert);
                        unWork.Commit();
                    }

                }
                catch (Exception ex)
                {
                 
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
                    var proId           = Convert.ToInt32(txtIND.Text);
                    var repository      = new Repository<Depot>(unWork);
                    var que             = repository.Id(proId);
                        que.Code        = txtICD.Text;
                        que.ProductId   = GetProductId(cmbNAM.Text);
                        que.DeliveryNo  = txtDEL.Text;
                        que.ReceiptNo   = txtREC.Text;
                        que.QtyStock    = Convert.ToDecimal(txtQTY.Text);
                        que.BranchId    = GetBranchId(cmbDIS.Text);
                        que.LastCost    = Convert.ToDecimal(txtLST.Text);
                        que.OnOrder     = Convert.ToInt32(txtORD.Text);
                        que.PurDate     = dkpPUR.Value.Date;
                        que.InvDate     = dkpDET.Value.Date;
                        que.WarrantyId  = GetWarrantyId(cmbWAR.Text);
                        que.StatusId    = GetProductStatus(cmbSAT.Text);
                        var result      = repository.Update(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, "Product Name: " + cmbNAM.Text.Trim(' ') + " " + Messages.SuccessUpdate,
                         Messages.TitleSuccessUpdate);
                        unWork.Commit();
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
                    var proId = Convert.ToInt32(txtIND.Text);
                    var repository = new Repository<Depot>(unWork);
                    var que = repository.Id(proId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, "Product Name: " + cmbNAM.Text.Trim(' ') + " " + Messages.SuccessDelete,
                         Messages.TitleSuccessDelete);
                        unWork.Commit();
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
            if (cmbNAM.Text.Length > 0)
            {
                var imgId = GetProductImgId(cmbNAM.Text);
                DisplayImage(imgId);
            }
        }
        private void gridInventory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridInventory.RowCount > 0)
            {
                try
                {
                    var invId = (int)((GridView)sender).GetFocusedRowCellValue("Id");
                    ShowValue(invId);
                    var imgId = GetProductImgId(cmbNAM.Text);
                    DisplayImage(imgId);
                    txtBAR.Text = SearchBarcode(cmbNAM.Text).Code;
                    lblPRZ.Text = SearchBarcode(cmbNAM.Text).RetailPrice.ToString(CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
               
            }
        }
        private void ShowValue(int inventoryId)
        {
            var ent = ShowEntity(inventoryId);
            txtIND.Text = ent.Id.ToString();
            txtICD.Text = ent.Code;
            cmbNAM.Text = ent.Item;
            txtDEL.Text = ent.DeliveryNo;
            txtREC.Text = ent.ReceiptNo;
            txtQTY.Text = ent.Qty.ToString(CultureInfo.InvariantCulture);
            cmbDIS.Text = ent.Branch;
            txtLST.Text = ent.LastCost.ToString(CultureInfo.InvariantCulture);
            txtORD.Text = ent.OnOrder.ToString();
            dkpPUR.Value = ent.Purchase;
            dkpDET.Value = ent.RefDate;
            cmbWAR.Text = ent.Warranty;
            cmbSAT.Text = ent.Status;
        }
        private void gridInventory_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhit();
        }
        private void gridInventory_LostFocus(object sender, EventArgs e)
        {
            InputDimG();
        }
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
            if (e.KeyCode == Keys.Enter)
            {
                var len = cmbNAM.Text.Length;
                if (len > 0)
                {
                    cmbNAM.BackColor = Color.White;
                    txtDEL.BackColor = Color.Yellow;
                    txtDEL.Focus();
                  
                    txtBAR.Text = SearchBarcode(cmbNAM.Text).Code;
                    lblPRZ.Text = SearchBarcode(cmbNAM.Text).RetailPrice.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Product Name in inventory must not be empty!", Messages.GasulPos);
                    cmbNAM.BackColor = Color.Yellow;
                    cmbNAM.Focus();
                }
            }
        }
        private void txtDEL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtDEL.Text.Length;
                if (len > 0)
                {
                    var inpt = string.Format(txtDEL.Text).ToUpper();
                    txtDEL.BackColor = Color.White;
                    txtREC.Focus();
                    txtREC.BackColor = Color.Yellow;
                    txtDEL.Text = inpt;
                }
                else
                {
                    txtDEL.BackColor = Color.White;
                    txtDEL.Text = Constant.DefaultNone;
                    txtREC.BackColor = Color.Yellow;
                    txtREC.Focus();
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
                    var inpt = string.Format(txtREC.Text).ToUpper();
                    txtREC.Text = inpt;
                    txtREC.BackColor = Color.White;
                    txtQTY.BackColor = Color.Yellow;
                    txtQTY.Focus();
                }
                else
                {
                    txtREC.Text = Constant.DefaultNone;
                    txtREC.BackColor = Color.White;
                    txtQTY.BackColor = Color.Yellow;
                    txtQTY.Focus();
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
            if (e.KeyCode == Keys.Enter)
            {
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
        }
        private void txtORD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtORD.Text.Length;
                if (len > 0)
                {
                    txtORD.BackColor = Color.White;
                    dkpPUR.Focus();
                }
                else
                {
                    txtORD.Text = @"0";
                    txtORD.BackColor = Color.White;
                    dkpPUR.Focus();
                }
              
            }
        }
        private void dkpPUR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dkpDET.Focus();
            }
        }
        private void GbPersonal_Paint(object sender, PaintEventArgs e)
        {

        }
        private void cmbWAR_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                BindProductWarranty();
            }
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputCaseLeave(cmbWAR, txtBAR, "Product Warranty",
                    Messages.TitleInventory);
            }
        }
        private void cmbNAM_Leave(object sender, EventArgs e)
        {
            cmbNAM.Size = new Size(269, 29);
            if (txtBAR.Text.Length > 0)
            {
                txtBAR.Text = SearchBarcode(cmbNAM.Text).Code;
                lblPRZ.Text = SearchBarcode(cmbNAM.Text).RetailPrice.ToString(CultureInfo.InvariantCulture);
               
            }
        }
        private void dkpDET_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbSAT.Focus();
            }
        }
        private void cmbNAM_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbNAM.Size = new Size(422, 29);
        }
        private void txtBAR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtBAR.Text.Length;
                if (len > 0)
                {
                    txtBAR.BackColor = Color.White;
                    bntSAV.Focus();
                }
                else
                {
                    txtBAR.BackColor = Color.Yellow;
                    txtBAR.Focus();
                    PopupNotification.PopUpMessages(0, "Product Barcode must not be empty!", Messages.GasulPos);
                }

            }
        }
         
        private void cmbSAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                BindProductStatus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                var len = cmbSAT.Text.Length;
                if (len > 0)
                {
                    cmbSAT.BackColor = Color.White;
                    cmbWAR.Focus();
                    cmbWAR.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Product status must not be empty!", Messages.GasulPos);
                    cmbSAT.Focus();
                    cmbSAT.BackColor = Color.Yellow;
                }
            }
        }
        private static int VerifyDelNo(string deliveryNo)
        {
            using (var session = new DalSession())
            {
                try
                {
                    var unWork = session.UnitofWrk;
                    var repository = new Repository<Depot>(unWork);
                    return repository.SelectAll(Query.SelectAllDepot)
                        .Where(x => x.DeliveryNo == deliveryNo)
                        .Select(x => x.DepotId)
                        .Count();
                }
                catch (Exception)
                {
                    return 0;
                }
               
            }
        }
        private static int VerifyReceiptNo(string receiptNo)
        {
            using (var session = new DalSession())
            {
                try
                {
                    var unWork = session.UnitofWrk;
                    var repository = new Repository<Depot>(unWork);
                    return repository.SelectAll(Query.SelectAllDepot)
                        .Where(x => x.ReceiptNo == receiptNo)
                        .Select(x => x.DepotId)
                        .Count();
                }
                catch (Exception)
                {
                    return 0;
                }

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
                    var query = repository.FindBy(x => x.Name == input);
                    return query.ProductId;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Product Id Error", "Inventory Details");
                    throw;
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
        private static int GetProductImgId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewProductCategory>(unWork);
                    var query = repository.FindBy(x => x.Name == input);
                    return query.ImageId;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Image Id Error", "Product Details");
                    throw;
                }
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
                    var query = repository.FindBy(x => x.Name == input);
                    return query;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Product entity Error", "Inventory Details");
                    throw;
                }
            }
        }
        private static ViewDepot ShowEntity(int inventoryId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewDepot>(unWork);
                    var query = repository.FindBy(x => x.Id == inventoryId);
                    return query;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        }
        private static IEnumerable<ViewDepot> RebindInventory(DateTime refDate)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewDepot>(unWork);
                    return repository.SelectAll(Config.Query.SelectAllDepot)
                        .Where(x => x.RefDate==refDate)
                        .ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleInventory);
                    throw;
                }
            }
        }

        private static string GetLastDeliveryNo()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewDepot>(unWork);
                    return repository.SelectAll(Config.Query.SelectAllDeliv)
                           .Select(x => x.DeliveryNo).FirstOrDefault();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleInventory);
                    return null;
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
                    var query = repository.FindBy(x => x.BranchId == branchId);
                    return query.BranchDetails;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Branch Id Error", "Inventory Details");
                    return null;
                }
            }
        }

        private void txtDEL_Leave(object sender, EventArgs e)
        {
            var len = txtDEL.Text.Length;
            if (len <= 0)return;
            txtREC.Text = txtDEL.Text.Trim(' ');
        }

        private static string GetLastCode()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<ViewDepot>(unitWork);
                var result = (from b in repository.SelectAll(Query.SelectAllDepot)
                              orderby b.Id descending
                              select b.Code).Take(1).SingleOrDefault();
                if (result != null) return result;
                result = Query.DefaultCode;
                return result;
            }
        }
        private static byte[] GetByImage(int imgId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ProductImages>(unWork);
                    var query = repository.FindBy(x => x.ImageId == imgId);
                    return query.ProductImage;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
        }
    }
}
