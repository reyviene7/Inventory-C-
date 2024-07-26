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
using Inventory.Services;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using Query = ServeAll.Core.Queries.Query;

namespace Inventory.MainForm
{
    public partial class FirmWareHouseDelivery : Form
    {
        public FirmMain Main { protected get; set; }
        private bool _add, _del, _edt, _wer, _bra;
        private readonly int _userId;
        private readonly int _userTy;
        public FirmWareHouseDelivery(int userId, int userTy)
        {
            _userId = userId;
            _userTy = userTy;
            InitializeComponent();
        }
        private void FirmInvDelivery_Load(object sender, EventArgs e)
        {
            
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
           ButtonClr();
        }
        private void bntCAN_Click(object sender, EventArgs e)
        {
            ButCan();
        }
        private void bntDEL_Click(object sender, EventArgs e)
        {
            if (_bra && _wer == false)
            {
                InputWhit();
                var que =
                    PopupNotification.PopUpMessageQuestion(
                        "Are you sure you want to Delivery No: " + txtDEL.Text.Trim(' ') + " " + "?", "Delivery Details");
                if (que)
                {
                    ButDel();
                }
                else { ButCan(); }
            }
        }
        private void bntHOM_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }
        private void cmbNAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_wer && _bra == false)
            {
                if (cmbNAM.Text.Length > 0)
                {
                    var imgId = GetProductImgId(cmbNAM.Text);
                    DisplayImage(imgId);
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
//KEY DOWN
        private void cmbNAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                BindProducts();
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (_wer && _bra == false)
                {
                    var len = cmbNAM.Text.Length;
                    if (len > 0)
                    {
                        cmbNAM.BackColor = Color.White;
                        txtDEL.BackColor = Color.Yellow;
                        txtDEL.Focus();
                        txtBAR.Text = SearchBarcode(cmbNAM.Text).Code;
                        txtPRC.Text = SearchBarcode(cmbNAM.Text).RetailPrice.ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        PopupNotification.PopUpMessages(0, "Product Name in inventory must not be empty!", Messages.GasulPos);
                        cmbNAM.BackColor = Color.Yellow;
                        cmbNAM.Focus();
                    }
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
                    txtDEL.BackColor = Color.White;
                    txtREC.Focus();
                    txtREC.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Delivery No must not be empty!", Messages.GasulPos);
                    txtDEL.BackColor = Color.Yellow;
                    txtDEL.Focus();
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
                    txtREC.BackColor = Color.White;
                    txtQTY.Focus();
                    txtQTY.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Receipt No must not be empty!", Messages.GasulPos);
                    txtREC.BackColor = Color.Yellow;
                    txtREC.Focus();
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
                    cmbDIS.Focus();
                    cmbDIS.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Quantity to deliver must not be empty!", Messages.GasulPos);
                    txtQTY.BackColor = Color.Yellow;
                    txtQTY.Focus();
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
                    dkpPUR.Focus();
                    dkpPUR.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Branch must not be empty!", Messages.GasulPos);
                    cmbDIS.BackColor = Color.Yellow;
                    cmbDIS.Focus();
                }
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
                    txtORD.Focus();
                    txtORD.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Price on Last Order must not be empty!", Messages.GasulPos);
                    txtLST.BackColor = Color.Yellow;
                    txtLST.Focus();
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
                    dkpPUR.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "On Order must not be empty!", Messages.GasulPos);
                    txtORD.BackColor = Color.Yellow;
                    txtORD.Focus();
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
        private void dkpDET_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbSAT.Focus();
            }
        }
        private void cmbSAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                BindStatus();
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
                    PopupNotification.PopUpMessages(0, "Product Status must not be empty!", Messages.GasulPos);
                    cmbSAT.BackColor = Color.Yellow;
                    cmbSAT.Focus();
                }
            }
        }
        private void cmbWAR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                BindWarranty();
            }
            if (e.KeyCode == Keys.Enter)
            {
                var len = cmbWAR.Text.Length;
                if (len > 0)
                {
                    cmbWAR.BackColor = Color.White;
                    bntSAV.Focus();
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Product Status must not be empty!", Messages.GasulPos);
                    cmbWAR.BackColor = Color.Yellow;
                    cmbWAR.Focus();
                }
            }
        }
        private void ButAdd()
        {
            if (_wer && _bra == false)
            {
                ButtonAdd();
                txtDEL.Enabled = true;
                txtREC.Enabled = true;
                txtQTY.Enabled = true;
                cmbDIS.Enabled = true;
                dkpPUR.Enabled = true;
                dkpDET.Enabled = true;
                cmbSAT.Enabled = true;
                cmbWAR.Enabled = true;
                txtDEL.Clear();
                txtREC.Clear();
                InputWhit();
                GenerateWareHouseCode();
            }
            //indProducts();
            cmbNAM.Enabled = false;
            BindBranch();
            BindProductStatus();
            BindProductWarranty();
            txtDEL.BackColor = Color.Yellow;
            txtDEL.Focus();
            _add = true;
            _edt = false;
            _del = false;
            gCON.Enabled = false;
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
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
        private void ButSav()
        {
            if (_add && _edt == false && _del == false)
            {
                if (_wer && _bra == false)
                {
                    InsertData();
                    ButtonSav();
                    InputDisb();
                    InputDimG();
                    InputClea();
                    ClearGrid();
                }
               
            }
            if (_add == false && _edt && _del == false)
            {

                if (_bra && _wer == false)
                {
                   UpdateBranch();
                    ButtonSav();
                    InputDisb();
                    InputDimG();
                    ClearGrid();
                    InputClea();
                }
            }
            if (_add == false && _edt == false && _del)
            {

                if (_bra && _wer == false)
                {
                    DeleteData();
                    ButtonSav();
                    InputDisb();
                    InputDimG();
                    InputClea();
                    ClearGrid();
                }
            }
            _add = false;
            _edt = false;
            _del = false;
            gCON.Enabled = true;
            cmbNAM.DataBindings.Clear();
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
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

        }
        private void InputWhit()
        {
            txtIND.BackColor = Color.White;
            txtCOD.BackColor = Color.White;
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
            txtCOD.Enabled = true;
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
            txtCOD.Enabled = false;
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
        private void InputClea()
        {
            txtIND.Clear();
            txtCOD.Clear();
            cmbNAM.Text = "";
            txtDEL.Clear();
            txtREC.Clear();
            txtQTY.Clear();
            cmbDIS.Text = "";
            cmbWAR.Text = @"NO WARRANTY";
            txtLST.Clear();
            txtORD.Clear();
            dkpPUR.Value = DateTime.Now.Date;
            dkpDET.Value = DateTime.Now.Date;
            cmbSAT.Text = "";
        }
        private void InputDimG()
        {
            txtIND.BackColor = Color.DimGray;
            txtCOD.BackColor = Color.DimGray;
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
        private void ClearGrid()
        {
            gCON.DataSource = null;
            gCON.DataSource = "";
            gridBranch.Columns.Clear();

        }
        private string GetLastWareHouseId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<ViewWareHouse>(unitWork);
                var result = (from b in repository.SelectAll(Query.SelectAllWareHouse)
                              orderby b.Id descending
                              select b.Code).Take(1).SingleOrDefault();
                if (result != null)
                {
                    return result;
                }
                result = Query.DefaultCode;
                return result;
            }
        }
        private string GetLastBranchesId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<ViewBranchDelivery>(unitWork);
                var result = (from b in repository.SelectAll(Query.SelectAllBranchDelivery)
                              orderby b.Id descending
                              select b.Code).Take(1).SingleOrDefault();
                if (result != null)
                {
                    return result;
                }
                result = Query.DefaultCode;
                return result;
            }
        }
        private void GenerateWareHouseCode()
        {
            var lastCode = GetLastWareHouseId();
            var lastId = GetSettings.GetLastBarcode(lastCode);
            var alphaNumeric = new GenerateAlpaNum(3, 2, lastId, "D");
            alphaNumeric.Increment();
            txtCOD.Text = alphaNumeric.ToString();
        }
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
        private byte[] GetByImage(int imgId)
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
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.ErrorInternal);
                    throw;
                }
            }
        }
        private void BindWareHouse()
        {
            braWET.ShowWaitForm();
            ClearGrid();
            gCON.DataSource = EnumerableWareHouse();
            if (gridBranch.RowCount > 0)
            {
                gridBranch.Columns[0].Width = 40;
                gridBranch.Columns[1].Width = 90;
                gridBranch.Columns[2].Width = 280;
                gridBranch.Columns[3].Width = 100;
                gridBranch.Columns[3].Width = 120;
            }
            braWET.CloseWaitForm();
        }
        private void BindBranchDel()
        {
            braWET.ShowWaitForm();
            ClearGrid();
            gCON.DataSource = EnumerableBranch();
            if (gridBranch.RowCount > 0)
            {
                gridBranch.Columns[0].Width = 40;
                gridBranch.Columns[1].Width = 90;
                gridBranch.Columns[2].Width = 280;
                gridBranch.Columns[3].Width = 100;
                gridBranch.Columns[3].Width = 120;
            }
            braWET.CloseWaitForm();

        }
        private void BindProducts()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Products>(unWork);
                var query = (from r in repository.SelectAll(Query.AllProducts)
                    where r.Name.Contains(Constant.AddFilterLpg)
                    where !r.Name.Contains(Constant.AddFilterEmp)
                    select r.Name.Distinct()).ToList();
                cmbNAM.DataBindings.Clear();
                cmbNAM.DataSource = query;
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
        private void BindBranch()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Branch>(unWork);
                var query = repository.SelectAll(Query.SelectAllBranchExcWareH).Select(x => x.BranchDetails).Distinct().ToList();
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
        private void ShowValue(int inventoryId)
        {
            var ent = ShowEntity(inventoryId);
            txtIND.Text = ent.Id.ToString();
            txtCOD.Text = ent.Code;
            cmbNAM.Text = ent.Item;
            txtDEL.Text = ent.Delivery;
            txtREC.Text = ent.Receipt;
            txtQTY.Text = ent.Qty.ToString(CultureInfo.InvariantCulture);
            cmbDIS.Text = ent.Branch;
            txtLST.Text = ent.LastCost.ToString(CultureInfo.InvariantCulture);
            txtORD.Text = ent.OnOrder.ToString();
            dkpPUR.Value = ent.Purchase;
            dkpDET.Value = ent.RefDate;
            cmbWAR.Text = ent.Warranty;
            cmbSAT.Text = ent.Status;
            txtDIP.Text = ent.DepotId.ToString();
        }
        private void ShowBranch(int inventoryId)
        {
            var ent = ShowDelivery(inventoryId);
            txtIND.Text = ent.Id.ToString();
            txtCOD.Text = ent.Code;
            cmbNAM.Text = ent.Item;
            txtDEL.Text = ent.Delivery;
            txtREC.Text = ent.Receipt;
            txtQTY.Text = ent.Qty.ToString(CultureInfo.InvariantCulture);
            cmbDIS.Text = ent.Branch;
            txtLST.Text = Constant.DefaultZero.ToString();
            txtORD.Text = Constant.DefaultZero.ToString();
            dkpPUR.Value = ent.RefDate;
            dkpDET.Value = ent.RefDate;
            cmbWAR.Text = ent.Warranty;
            cmbSAT.Text = ent.Status;
            txtDIP.Text = ent.WareHouseId.ToString();
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
        private static int VerifyDelNo(string deliveryNo)
        {
            using (var session = new DalSession())
            {
                try
                {
                    var unWork = session.UnitofWrk;
                    var repository = new Repository<ViewBranchDelivery>(unWork);
                    return repository.SelectAll(Query.SelectAllDepot)
                        .Where(x => x.Delivery == deliveryNo)
                        .Select(x => x.Id)
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
                    var repository = new Repository<ViewBranchDelivery>(unWork);
                    return repository.SelectAll(Query.SelectAllDepot)
                        .Where(x => x.Receipt == receiptNo)
                        .Select(x => x.Id)
                        .Count();
                }
                catch (Exception)
                {
                    return 0;
                }

            }
        }
        private static ViewWareHouse ShowEntity(int inventoryId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewWareHouse>(unWork);
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
        private static ViewBranchDelivery ShowDelivery(int inventoryId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewBranchDelivery>(unWork);
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
        private static IEnumerable<ViewWareHouse> EnumerableWareHouse()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewWareHouse>(unWork);
                    return repository.SelectAll(Query.SelectAllWareHouse)
                        .ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleInventory);
                    throw;
                }
            }
        }
        private static IEnumerable<ViewBranchDelivery> EnumerableBranch()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewBranchDelivery>(unWork);
                    return repository.SelectAll(Query.SelectAllBranchDelivery)
                        .ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleInventory);
                    throw;
                }
            }
        }
        private void InsertData()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    braWET.ShowWaitForm();
                    var branchDel = new BranchDelivery
                    {
                        Code         = txtCOD.Text.Trim(' '),
                        ProductId    = GetProductId(cmbNAM.Text),
                        WareHouseId  = int.Parse(txtIND.Text),
                        QtyStock     = decimal.Parse(txtQTY.Text),
                        DeliveryNo   = txtDEL.Text.Trim(' '),
                        ReceiptNo    = txtREC.Text.Trim(' '),
                        BranchId     = GetBranchId(cmbDIS.Text),
                        LastCost     = decimal.Parse(txtLST.Text),
                        OnOrder      = int.Parse(txtORD.Text),
                        WarrantyId   = GetWarrantyId(cmbWAR.Text),
                        StatusId     = GetProductStatus(cmbSAT.Text),
                        DeliveryDate = dkpPUR.Value.Date
                    };
                    var quantity = txtQTY.Text.Trim(' ');
                    var product = cmbNAM.Text.Trim(' ');
                    var branch = cmbDIS.Text.Trim(' ');
                    unWork.Begin();
                    var repository = new Repository<BranchDelivery>(unWork);
                    var result = repository.Add(branchDel);
                    if (result > 0)
                    {
                        braWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Item Name: " + product + " with quantity " + quantity + " successfully delivered to branch " + branch, Messages.GasulPos);
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
        private void UpdateBranch()
        {
            using (var session = new DalSession())
            {
                var deliveryId = int.Parse(txtIND.Text);
                var unWork = session.UnitofWrk;
                try
                {
                braWET.ShowWaitForm();
                unWork.Begin();
                var repository = new Repository<BranchDelivery>(unWork);
                var que = repository.FindBy(x => x.BranchDeliveryId == deliveryId);
                que.Code        = txtCOD.Text;
                que.ProductId   = GetProductId(cmbNAM.Text);
                que.WareHouseId = int.Parse(txtDIP.Text);
                que.QtyStock    = decimal.Parse(txtQTY.Text);
                que.DeliveryNo  = txtDEL.Text.Trim(' ');
                que.ReceiptNo   = txtREC.Text.Trim(' ');
                que.BranchId    = GetBranchId(cmbDIS.Text);
                que.LastCost    = decimal.Parse(txtLST.Text);
                que.OnOrder     = int.Parse(txtORD.Text);
                que.WarrantyId  = GetWarrantyId(cmbWAR.Text);
                que.StatusId    = GetProductStatus(cmbSAT.Text);
                que.DeliveryDate = dkpPUR.Value.Date;
                var result      = repository.Update(que);
                    if (result)
                    {
                        braWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Delivery Id: " + deliveryId + " successfully Updated!",
                            Messages.GasulPos);
                    }
                    else
                    {
                        braWET.CloseWaitForm();
                        unWork.Rollback();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
        private void DeleteData()
        {
            var deliverId = int.Parse(txtIND.Text);
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    braWET.ShowWaitForm();
                    unWork.Begin();
                    var repository = new Repository<BranchDelivery>(unWork);
                    var query = repository.FindBy(x => x.BranchDeliveryId == deliverId);
                    var result = repository.Delete(query);
                    if (result)
                    {
                        braWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1,
                            "Delivery No: " + txtDEL.Text.Trim(' ') + " successfully Deleted!", Messages.GasulPos);
                    }
                    else
                    {
                        braWET.CloseWaitForm();
                        unWork.Rollback();
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.ToString());
                }
            }
        }
        private void gridBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                _wer = true;
                _bra = false;
                bntADD.BackColor = Color.Red;
                bntADD.Enabled = true;
                PopupNotification.PopUpMessages(1, "Warehouse Inventory List", Messages.GasulPos);
                BindWareHouse();
            }
            if (e.KeyCode == Keys.F2)
            {
                ButCan();
                _wer = false;
                _bra = true;
                bntADD.BackColor = Color.DimGray;
                bntADD.Enabled = false;
                PopupNotification.PopUpMessages(1, "Warehouse Delivery to Branches Inventory List", Messages.GasulPos);
                BindBranchDel();
            }
        }
        private void gridBranch_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridBranch.RowCount > 0)
            {
                try
                {
                    if (_wer && _bra == false)
                    {
                        var invId = (int)((GridView)sender).GetFocusedRowCellValue("Id");
                        ShowValue(invId);
                        var imgId = GetProductImgId(cmbNAM.Text);
                        DisplayImage(imgId);
                        txtBAR.Text = SearchBarcode(cmbNAM.Text).Code;
                        txtPRC.Text = SearchBarcode(cmbNAM.Text).RetailPrice.ToString(CultureInfo.InvariantCulture);
                    }
                    if (_wer == false && _bra)
                    {
                        var invId = (int)((GridView)sender).GetFocusedRowCellValue("Id");
                        ShowBranch(invId);
                        var imgId = GetProductImgId(cmbNAM.Text);
                        DisplayImage(imgId);
                        txtBAR.Text = SearchBarcode(cmbNAM.Text).Code;
                        txtPRC.Text = SearchBarcode(cmbNAM.Text).RetailPrice.ToString(CultureInfo.InvariantCulture);
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }
        private void gridBranch_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridBranch.RowCount > 0)
            {
                InputWhit();
            }
        }
    }
}
