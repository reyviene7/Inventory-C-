using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Inventory.Config;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using Query = ServeAll.Core.Queries.Query;


namespace Inventory.MainForm
{
    public partial class FirmProducts : Form
    {
        private FirmMain _main;
        private bool _add, _edt, _del;
        public FirmMain Main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FirmProducts()
        {
            InitializeComponent();
        }

        private void FrmProducts_Load(object sender, EventArgs e)
        {
            
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            BindProductList();
         
        }

        private void FrmProducts_MouseMove(object sender, MouseEventArgs e)
        {
            PanelInterface.MouseMOve(this, pnlRightOptions, e);
        }

        private void Options_Tick(object sender, EventArgs e)
        {
            PanelInterface.OptionTick(this, pnlOptions);
        }

        private void RightOptions_Tick(object sender, EventArgs e)
        {
            PanelInterface.RightOptionTick(this, pnlRightOptions);
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
                    "Are you sure you want to Delete Product: " + txtNAM.Text.Trim(' ') + " " + "?", "Product Details");
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
        private void pbLogout_Click(object sender, EventArgs e)
        {
            var que = PopupNotification.PopUpMassageLogOff();
            if (que <= 0) return;
            var log = new FirmLogin();
            log.Show();
            Close();
           
        }
        private void pbHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }
        private void pbExit_Click(object sender, EventArgs e)
        {
            PopupNotification.PopUpMessageExit();
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
        #region ButtonCRUD
        private void ButAdd()
        {
            ButtonAdd();
            InputEnab();
            InputWhit();
            InputClea();
           
            BindSupplier();
            BindCategory();
            BindStatus();
            txtCOD.Focus();
            _add = true;
            _edt = false;
            _del = false;
            gCON.Enabled = false;
            imgPRO.DataBindings.Clear();
            imgBIG.DataBindings.Clear();
            imgBIG.Image = null;
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
        private void ButClr()
        {
            ButtonClr();
            InputEnab();
            InputWhit();
            InputClea();
            gCON.Enabled = true;
            cmbCAT.DataBindings.Clear();
            cmbSUP.DataBindings.Clear();
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
                BindProductList();
                
            }
            if (_add == false && _edt && _del == false)
            {
              
                DataUpdate();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindProductList();
               
            }
            if (_add == false && _edt == false && _del)
            {
                
                DataDelete();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindProductList();
                
            }
            _add = false;
            _edt = false;
            _del = false;
            gCON.Enabled = true;
            cmbCAT.DataBindings.Clear();
            cmbSUP.DataBindings.Clear();
            imgPRO.DataBindings.Clear();
            imgBIG.DataBindings.Clear();
            imgBIG.Image = null;
            imgPRO.Image = null;
        }
        private void ButCan()
        {
            ButtonCan();
            InputDisb();
            InputDimG();
            InputClea();
            gCON.Enabled = true;
            cmbCAT.DataBindings.Clear();
            cmbSUP.DataBindings.Clear();
       
        }
        #endregion
        private void DisplayImage(int imgId)
        {
            imgPRO.DataBindings.Clear();
            imgBIG.DataBindings.Clear();
            var img = GetByImage(imgId);
            if (img != null)
            {
                MemoryStream memoryStream = new MemoryStream(img);
                imgPRO.Image = Image.FromStream(memoryStream);
                imgBIG.Image = Image.FromStream(memoryStream);
            }
            else
            {
                imgPRO.Image = null;
                imgBIG.Image = null;
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
                    var query = repository.FindBy(x => x.image_id == imgId);
                    return query.image;
                }
                catch (Exception ex)
                {
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.ErrorInternal);
                    throw;
                }
            }
        }
        private void BindProductList()
        {
            gCON.Update();
            try
            {
                splash.ShowWaitForm();
                gCON.DataBindings.Clear();
                gCON.DataSource = RebindProducts();
                gridProduct.Columns[0].Width = 40;
                gridProduct.Columns[1].Width = 90;
                gridProduct.Columns[2].Width = 290;
                gridProduct.Columns[5].Width = 55;
                splash.CloseWaitForm();
            }
            catch (Exception ex)
            {
                gCON.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableSupplier);
            }
        }
        private void BindCategory()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Category>(unWork);
                var query = repository.SelectAll(Query.AllCategory).Select(x => x.category_details).Distinct().ToList();
                cmbCAT.DataBindings.Clear();
                cmbCAT.DataSource = query;
            }
        }
        private void BindStatus()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<MerchandiseStatus>(unWork);
                var query = repository.SelectAll(Query.AllMerchandiseStatus).Select(x => x.status_details).Distinct().ToList();
                cmbDIS.DataBindings.Clear();
                cmbDIS.DataSource = query;
            }
        }
        private void BindSupplier()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Supplier>(unWork);
                var query = repository.SelectAll(Query.AllSupplier).Select(x => x.supplier_name).Distinct().ToList();
                cmbSUP.DataBindings.Clear();
                cmbSUP.DataSource = query;
            }
        }
        private int GetCategoryId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Category>(unWork);
                    var query = repository.FindBy(x => x.category_details == input);
                    return query.category_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "CategoryId Error", "Product Details");
                    throw;
                }
            }
        }
        private int GetStatusId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<MerchandiseStatus>(unWork);
                    var query = repository.FindBy(x => x.status_details == input);
                    return query.status_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Status Id Error", "Product Details");
                    return 0;
                }
            }
        }
        private int GetSupplierId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Supplier>(unWork);
                    var query = repository.FindBy(x => x.supplier_name == input);
                    return query.supplier_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Supplier Id Error", "Product Details");
                    throw;
                }
            }
        }
        private ViewProducts Product()
        {
            var productId = int.Parse(txtPID.Text);
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewProducts>(unWork);
                    return repository.FindBy(x => x.product_id == productId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }

            }
        }
        private int GetProductImgId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Category>(unWork);
                    var query = repository.FindBy(x => x.category_details == input);
                    return query.image_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Image Id Error", "Product Details");
                    throw;
                }
            }
        }
        private IEnumerable<ProductViews> RebindProducts()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ProductViews>(unWork);
                    return repository.SelectAll(Query.AllViewProducts).ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleProducts);
                    throw;
                }
            }
        }
        private void InputWhit()
        {
            txtPID.BackColor = Color.White;
            txtCOD.BackColor = Color.White;
            txtNAM.BackColor = Color.White;
            cmbCAT.BackColor = Color.White;
            cmbSUP.BackColor = Color.White;
            txtSTC.BackColor = Color.White;
            txtBRD.BackColor = Color.White;
            txtMOD.BackColor = Color.White;
            txtMAD.BackColor = Color.White;
            txtSER.BackColor = Color.White;
            txtWET.BackColor = Color.White;
            txtNET.BackColor = Color.White;
            txtTRD.BackColor = Color.White;
            txtRET.BackColor = Color.White;
            txtWHL.BackColor = Color.White;
            cmbDIS.BackColor = Color.White;
            dkpREG.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtPID.Enabled = true;
            txtCOD.Enabled = true;
            txtNAM.Enabled = true;
            cmbCAT.Enabled = true;
            cmbSUP.Enabled = true;
            txtSTC.Enabled = true;
            txtBRD.Enabled = true;
            txtMOD.Enabled = true;
            txtMAD.Enabled = true;
            txtSER.Enabled = true;
            txtWET.Enabled = true;
            txtNET.Enabled = true;
            txtTRD.Enabled = true;
            txtRET.Enabled = true;
            txtWHL.Enabled = true;
            cmbDIS.Enabled = true;
            dkpREG.Enabled = true;
        }
        private void InputDisb()
        {
            txtPID.Enabled = false;
            txtCOD.Enabled = false;
            txtNAM.Enabled = false;
            cmbCAT.Enabled = false;
            cmbSUP.Enabled = false;
            txtSTC.Enabled = false;
            txtBRD.Enabled = false;
            txtMOD.Enabled = false;
            txtMAD.Enabled = false;
            txtSER.Enabled = false;
            txtWET.Enabled = false;
            txtNET.Enabled = false;
            txtTRD.Enabled = false;
            txtRET.Enabled = false;
            txtWHL.Enabled = false;
            cmbDIS.Enabled = false;
            dkpREG.Enabled = false;
        }
        private void InputClea()
        {
            txtPID.Clear();
            txtCOD.Clear();
            txtNAM.Clear();
            cmbCAT.Text = "";
            cmbSUP.Text = "";
            txtSTC.Clear();
            txtBRD.Clear();
            txtMOD.Clear();
            txtMAD.Clear();
            txtSER.Clear();
            txtWET.Clear();
            txtNET.Clear();
            cmbDIS.Text = "";
            txtTRD.Clear();
            txtRET.Clear();
            txtWHL.Clear();

            dkpREG.Value = DateTime.Now.Date;
        }
        private void InputDimG() {
            txtPID.BackColor = Color.DimGray;
            txtCOD.BackColor = Color.DimGray;
            txtNAM.BackColor = Color.DimGray;
            cmbCAT.BackColor = Color.DimGray;
            cmbSUP.BackColor = Color.DimGray;
            txtSTC.BackColor = Color.DimGray;
            txtBRD.BackColor = Color.DimGray;
            txtMOD.BackColor = Color.DimGray;
            txtMAD.BackColor = Color.DimGray;
            txtSER.BackColor = Color.DimGray;
            txtWET.BackColor = Color.DimGray;
            txtNET.BackColor = Color.DimGray;
            txtTRD.BackColor = Color.DimGray;
            txtRET.BackColor = Color.DimGray;
            txtWHL.BackColor = Color.DimGray;
            cmbDIS.BackColor = Color.DimGray;
            dkpREG.BackColor = Color.DimGray;
        }
        private string GetLastId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<ViewProducts>(unitWork);
                var result = (from b in repository.SelectAll(Query.AllProducts)
                              orderby b.product_id descending
                              select b.stock_code).Take(1).SingleOrDefault();
                if (result != null)
                {
                    return result;
                }
                result = Query.DefaultCode;
                return result;
            }
        }
        private void GenerateCode()
        {
            var lastCode = GetLastId();
            var lastId = GetSettings.GetLastBarcode(lastCode);
            var alphaNumeric = new GenerateAlpaNum(3, 2, lastId, "PR");
            alphaNumeric.Increment();
            txtSTC.Text = alphaNumeric.ToString();
        }
        private void DataInsert()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk; 
                unWork.Begin();
                try
                {
                    splash.ShowWaitForm();
                    var repository = new Repository<Products>(unWork);
                    var product = new Products()
                    {
                        product_code            = txtCOD.Text.Trim(' '),
                        product_name            = txtNAM.Text.Trim(' '),
                        category_id      = GetCategoryId(cmbCAT.Text),
                        supplier_id      = GetSupplierId(cmbSUP.Text),
                        stock_code       = txtSTC.Text.Trim(' '),
                        brand           = txtBRD.Text.Trim(' '),
                        model           = txtMOD.Text.Trim(' '),
                        made            = txtMAD.Text.Trim(' '),
                        serial_number          = txtSER.Text.Trim(' '),
                        tare_weight      = Convert.ToDecimal(txtWET.Text),
                        net_weight       = Convert.ToDecimal(txtNET.Text),
                        trade_price      = Convert.ToDecimal(txtTRD.Text),
                        retail_price     = Convert.ToDecimal(txtRET.Text),
                        wholesale       = Convert.ToDecimal(txtWHL.Text), 
                        status_id        = GetStatusId(cmbDIS.Text),
                        date_register        = dkpREG.Value.Date
                    };
                    var result = repository.Add(product);
                    if (result > 0)
                    {
                        splash.ShowWaitForm();
                        PopupNotification.PopUpMessages(1,
                            "Product Name: " + txtNAM.Text.Trim(' ') + " " + Messages.SuccessInsert,
                            Messages.TitleSuccessInsert);
                        unWork.Commit();
                    }
                    else
                    {
                        splash.ShowWaitForm();
                        unWork.Rollback();
                    }

                    
                }
                catch (Exception ex)
                {
                   
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
                    splash.ShowWaitForm();
                    var proId = Convert.ToInt32(txtPID.Text);
                    var repository = new Repository<Products>(unWork);
                    var que = repository.Id(proId);

                    que.product_code        = txtCOD.Text.Trim(' ');
                    que.product_name        = txtNAM.Text.Trim(' ');
                    que.category_id  = GetCategoryId(cmbCAT.Text);
                    que.supplier_id  = GetSupplierId(cmbSUP.Text);
                    que.stock_code   = txtSTC.Text.Trim(' ');
                    que.brand       = txtBRD.Text.Trim(' ');
                    que.model       = txtMOD.Text.Trim(' ');
                    que.made        = txtMAD.Text.Trim(' ');
                    que.serial_number      = txtSER.Text.Trim(' ');
                    que.tare_weight  = Convert.ToDecimal(txtWET.Text);
                    que.net_weight   = Convert.ToDecimal(txtNET.Text);
                    que.trade_price = Convert.ToDecimal(txtTRD.Text);
                    que.retail_price = Convert.ToDecimal(txtRET.Text);
                    que.wholesale = Convert.ToDecimal(txtWHL.Text);
                    que.status_id    = GetStatusId(cmbDIS.Text);
             
                    que.date_register    = dkpREG.Value.Date;
                    var result      = repository.Update(que);
                    if (result)
                    {
                        splash.CloseWaitForm();
                        PopupNotification.PopUpMessages(1,
                            "Product Name: " + txtNAM.Text.Trim(' ') + " " + Messages.SuccessUpdate,
                            Messages.TitleSuccessUpdate);
                        unWork.Commit();
                    }
                    else
                    {
                        splash.CloseWaitForm();
                        unWork.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    
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
                    splash.ShowWaitForm();
                    var proId = Convert.ToInt32(txtPID.Text);
                    var repository = new Repository<Products>(unWork);
                    var que = repository.Id(proId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        splash.CloseWaitForm();
                        PopupNotification.PopUpMessages(1,
                            "Product Name: " + txtNAM.Text.Trim(' ') + " " + Messages.SuccessDelete,
                            Messages.TitleSuccessDelete);
                        unWork.Commit();
                    }
                    else
                    {
                        splash.CloseWaitForm();
                        unWork.Rollback();
                    }
                }
                catch (Exception ex)
                {
                   
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedDelete);

                }
            }
        }
        private void gridProduct_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridProduct.RowCount > 0)
            {
                try
                {
                    txtPID.Text = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    txtCOD.Text = Product().product_code;
                    txtNAM.Text = Product().product_name;
                    cmbCAT.Text = Product().category_details;
                    cmbSUP.Text = Product().supplier_name;
                    txtSTC.Text = Product().stock_code;
                    txtBRD.Text = Product().brand;
                    txtMOD.Text = Product().model;
                    txtMAD.Text = Product().made;
                    txtSER.Text = Product().serial_number;
                    txtWET.Text = Product().tare_weight.ToString(CultureInfo.InvariantCulture);
                    txtNET.Text = Product().net_weight.ToString(CultureInfo.InvariantCulture);
                    txtTRD.Text = Product().trade_price.ToString(CultureInfo.InvariantCulture);
                    txtRET.Text = Product().retail_price.ToString(CultureInfo.InvariantCulture);
                    txtWHL.Text = Product().wholesale.ToString(CultureInfo.InvariantCulture);
                    cmbDIS.Text = Product().status_details;
                    dkpREG.Value = Product().date_register;
                    var cat = cmbCAT.Text.Trim(' ');
                    var imgId = GetProductImgId(cat);
                    DisplayImage(imgId);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());
                }
                
            }
        }
        private void gridProduct_LostFocus(object sender, EventArgs e)
        {
            InputDimG();
        }
        private void gridProduct_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            InputWhit();
        }

        #region stringManipulation
        private void txtNAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtNAM, cmbCAT, "Product Name",
                Messages.TitleProducts);
            }
        }

        private void cmbCAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(cmbCAT, cmbSUP, "Product Category",
                Messages.TitleProducts);
            }
            if (e.KeyCode == Keys.F1)
            {
                BindCategory();
            }
        }

        private void cmbSUP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(cmbSUP, txtSTC, "Product Supplier",
                Messages.TitleProducts);
            }
            if (e.KeyCode == Keys.F1)
            {
                BindSupplier();
            }
        }

        private void txtSTC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtSTC, txtBRD, "Stock Code",
                Messages.TitleProducts);
            }
        }

        private void txtBRD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtBRD, txtMOD, "Product Brand",
                Messages.TitleProducts);
            }
        }

        private void txtMOD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtMOD, txtMAD, "Product Model",
                Messages.TitleProducts);
            }
        }

        private void txtMAD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtMAD, txtSER, "Product Made",
                Messages.TitleProducts);
            }
        }

        private void txtSER_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtSER, txtWET, "Serial Number",
                Messages.TitleProducts);
            }
        }

        private void txtWET_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtWET, txtNET, "Tare Weight",
                Messages.TitleProducts);
            }
        }
        private void txtNET_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtNET, txtTRD, "Net Weight",
                Messages.TitleProducts);
            }
        }

        private void txtWET_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtWET.Focus();
                txtWET.BackColor = Color.Yellow;
            }
            else
            {
                txtWET.BackColor = Color.White;
            }
        }
        private void txtNET_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtNET.Focus();
                txtNET.BackColor = Color.Yellow;
            }
            else
            {
                txtNET.BackColor = Color.White;
            }
        }

        private void txtWET_Leave(object sender, EventArgs e)
        {
            InputManipulation.DetectIntLeave(txtWET);
        }

        private void txtNET_Leave(object sender, EventArgs e)
        {
            InputManipulation.DetectIntLeave(txtNET);
        }

        private void cmbCAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_add || _edt)
            {
                var cat = cmbCAT.Text.Trim(' ');
                var imgId = GetProductImgId(cat);
                DisplayImage(imgId);
            }
        }
        private void cmbDIS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbDIS, dkpREG, "Discontinued",
                Messages.TitleProducts);
            }
            if (e.KeyCode == Keys.F1)
            {
                BindStatus();
            }
        }

        private void txtTRD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtTRD.Focus();
                txtTRD.BackColor = Color.Yellow;
            }
            else
            {
                txtTRD.BackColor = Color.White;
            }
        }

        private void txtTRD_Leave(object sender, EventArgs e)
        {
            InputManipulation.DetectIntLeave(txtTRD);
        }

        private void txtRET_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtRET.Focus();
                txtRET.BackColor = Color.Yellow;
            }
            else
            {
                txtRET.BackColor = Color.White;
            }
        }

        private void txtRET_Leave(object sender, EventArgs e)
        {
            InputManipulation.DetectIntLeave(txtRET);
        }

        private void txtWHL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtWHL.Focus();
                txtWHL.BackColor = Color.Yellow;
            }
            else
            {
                txtWHL.BackColor = Color.White;
            }
        }

        private void txtWHL_Leave(object sender, EventArgs e)
        {
            InputManipulation.DetectIntLeave(txtWHL);
        }

        private void txtTRD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtTRD, txtRET, "Trade Price",
                Messages.TitleProducts);
            }
        }

        private void txtRET_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtRET, txtWHL, "Retail Price",
                Messages.TitleProducts);
            }
        }

        private void txtWHL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtWHL, cmbDIS, "Whole Sale Price",
                Messages.TitleProducts);
            }
        }

        private void txtCOD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var barcode = txtCOD.Text.Trim(' ');
                var que = VerifyCode(barcode);
                if (que == 0)
                {
                    InputManipulation.InputBoxLeave(txtCOD, txtNAM, "Barcode",
                        Messages.TitleProducts);
                    txtCOD.Enabled = true;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Product Barcode already exist!", Messages.GasulPos);
                    txtCOD.Focus();
                }


              
            }
        }

        private void txtCOD_Leave(object sender, EventArgs e)
        {
            //var barcode = txtCOD.Text.Trim(' ');
            //var len = txtCOD.Text.Length;
            //if (_del) return;
            //if (len > 0)
            //{
            //    var que = VerifyCode(barcode);
            //    if (que <= 0)
            //    {
            //        txtCOD.Focus();
            //        txtCOD.Enabled = true;
            //    }
            //    else
            //    {
            //        PopupNotification.PopUpMessages(0, "Product Barcode already exist!", Messages.GasulPos);
            //        txtCOD.Focus();
            //    }
            //}
            //else
            //    PopupNotification.PopUpMessages(0, "Product Barcode must not be empty!", Messages.GasulPos);
            //txtCOD.Focus();
        }

        private void dkpREG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(dkpREG, bntSAV, "Date Register", Messages.TitleProducts);
            }
        }


        #endregion

        private int VerifyCode(string barcode)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Products>(unWork);
                    var que = repository.FindBy(x => x.product_code ==barcode);
                    return que.product_id;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }
    }
}
