using DevExpress.Utils.About;
using DevExpress.Utils.DirectXPaint;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Inventory.Config;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Query = ServeAll.Core.Queries.Query;


namespace Inventory.MainForm
{
    public partial class FirmProducts : Form
    {
        private FirmMain _main;
        private bool _add, _edt, _del;
        private IEnumerable<ViewProducts> listProducts;
        private IEnumerable<ViewImageProduct> imgList;
        private int productId;
        private readonly int _userId;
        private readonly int _userTyp;
        public FirmMain Main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FirmProducts(int userId, int userTy)
        {
            _userId = userId;
            _userTyp = userTy;

            if (_userTyp != 1)
            {
                PopupNotification.PopUpMessages(0, Messages.AdminPrivilege, Messages.InventorySystem);

                this.DialogResult = DialogResult.Cancel;
                return;
            }
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
        }

        private void FrmProducts_Load(object sender, EventArgs e)
        {
            
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            bindRefreshed();
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
        private void gridProduct_LostFocus(object sender, EventArgs e)
        {
            InputDimG();
        }
        private void gridProduct_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            InputWhit();
            bntCancel.Enabled = true;
        }

        private void bntAdd_Click(object sender, EventArgs e)
        {
            ButAdd();
        }

        private void bntUpdate_Click(object sender, EventArgs e)
        {
            ButUpd();
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            ButSav();
        }

        private void bntClear_Click(object sender, EventArgs e)
        {
            ButClr();
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            ButCan();
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            InputWhit();
            InputDisb();
            var que =
                PopupNotification.PopUpMessageQuestion(
                    "Are you sure you want to Delete Product: " + txtProductName.Text.Trim(' ') + " " + "?", "Product Details");
            if (que)
            {
                ButDel();
            }
            else { ButCan(); }
        }

        private void bntHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png;*.gif)|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    string fileNameAndExtension = getfileExntesion(selectedFilePath);
                    txtImageFilename.Text = fileNameAndExtension;

                    if (imgBigPreview.Image != null)
                    {
                        imgBigPreview.Image.Dispose();
                        imgBigPreview.Image = null;
                    }

                    try
                    {
                        using (FileStream fs = new FileStream(selectedFilePath, FileMode.Open, FileAccess.Read))
                        {
                            using (Image temp = Image.FromStream(fs))
                            {
                                imgBigPreview.Image?.Dispose();
                                imgBigPreview.Image = new Bitmap(temp);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        PopupNotification.PopUpMessages(0, "Image Load Failed: " + ex.Message, "Load Error");
                        imgBigPreview.Image = null;
                        return;
                    }
                    btnSaveImage.Enabled = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var code = txtProductBar.Text.Trim(' ');
            var title = txtImageTitle.Text.Trim(' ');
            var imgtype = txtImageType.Text.Trim(' ');
            var imgLocation = txtImageFilename.Text.Trim(' ');
            if (code.Length > 0 && title.Length > 0 && imgtype.Length > 0 && imgLocation.Length > 0)
            {
                var result = saveProductImage();
                if (result > 0)
                {
                    if (imgBigPreview.Image != null)
                    {
                        imgBigPreview.Image.Dispose();
                        imgBigPreview.Image = null;
                    }

                    btnSaveImage.Enabled = false;
                    btnBrowse.Enabled = true;

                    txtImageFilename.Text = "";
                    txtImageTitle.Text = "";
                }
            }
            else
            {
                PopupNotification.PopUpMessages(0, "Please fill all the entries!", Messages.TitleFailedInsert);
            }
        }
        private void pcAdd_Click(object sender, EventArgs e)
        {
            ButAdd();
        }

        private void ButtonAdd()
        {
            bntAdd.Enabled = true;
            bntUpdate.Enabled = false;
            bntDelete.Enabled = false;
            bntSave.Enabled = true;
            bntClear.Enabled = false;
            bntCancel.Enabled = true;
            bntHome.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonUpd()
        {
            bntAdd.Enabled = false;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = false;
            bntSave.Enabled = true;
            bntClear.Enabled = false;
            bntCancel.Enabled = true;
            bntHome.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonDel()
        {
            bntAdd.Enabled = false;
            bntUpdate.Enabled = false;
            bntDelete.Enabled = true;
            bntSave.Enabled = true;
            bntClear.Enabled = false;
            bntCancel.Enabled = true;
            bntHome.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonSav()
        {
            bntAdd.Enabled = true;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
            bntSave.Enabled = false;
            bntClear.Enabled = true;
            bntCancel.Enabled = false;
            bntHome.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        private void ButtonClr()
        {
            bntAdd.Enabled = true;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
            bntSave.Enabled = false;
            bntClear.Enabled = false;
            bntCancel.Enabled = false;
            bntHome.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        private void ButtonCan()
        {
            bntAdd.Enabled = true;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
            bntSave.Enabled = false;
            bntClear.Enabled = true;
            bntCancel.Enabled = false;
            bntHome.Enabled = true;
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
            txtProductBarcode.Focus();
            _add = true;
            _edt = false;
            _del = false;
            gridControl.Enabled = false;
            imgProduct.DataBindings.Clear();
            imgBigPreview.DataBindings.Clear();
            imgBigPreview.Image = null;
            imgProduct.Image = null;
            GenerateCode();
        }
        private void ButUpd()
        {
            ButtonUpd();
            InputEnab();
            InputWhit();
            _add = false;
            _edt = true;
            _del = false;
            gridControl.Enabled = false;
            txtProductName.Focus();
        }
        private void ButDel()
        {
            ButtonDel();
            InputDisb();
            InputWhit();
            _add = false;
            _edt = false;
            _del = true;
            gridControl.Enabled = false;
        }
        private void ButClr()
        {
            ButtonClr();
            InputDisb();
            InputWhit();
            InputClea();
            gridControl.Enabled = true;
            cmbCategory.DataBindings.Clear();
            cmbSupplier.DataBindings.Clear();
        }
        private bool IsProduct(string productCode)
        {
            return listProducts.Any(x => x.product_code == productCode);
        }
        private ViewProducts GetSelectedProduct()
        {
            if (gridProductList.FocusedRowHandle >= 0)
            {
                return gridProductList.GetRow(gridProductList.FocusedRowHandle) as ViewProducts;
            }
            return null;
        }

        private void ButSav()
        {
            string productCode = txtProductBarcode.Text.Trim();

            if (_add && _edt == false && _del == false)
            {
                if (IsProduct(productCode))
                {
                    PopupNotification.PopUpMessages(0, "Product Barcode: " + productCode + " already exists in the Product.", Messages.TitleFailedInsert);
                    return;
                }
                DataInsert();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                bindRefreshed();

            }
            if (_add == false && _edt && _del == false)
            {
                DataUpdate();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                bindRefreshed();

            }
            if (_add == false && _edt == false && _del)
            {
                
                DataDelete();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                bindRefreshed();
            }
            _add = false;
            _edt = false;
            _del = false;
            gridControl.Enabled = true;
            cmbCategory.DataBindings.Clear();
            cmbSupplier.DataBindings.Clear();
            imgProduct.DataBindings.Clear();
            imgBigPreview.DataBindings.Clear();
            imgBigPreview.Image = null;
            imgProduct.Image = null;
            bindRefreshed();
        }
        private void ButCan()
        {
            ButtonCan();
            InputDisb();
            InputDimG();
            InputClea();
            gridControl.Enabled = true;
            cmbCategory.DataBindings.Clear();
            cmbSupplier.DataBindings.Clear();
       
        }
        #endregion
        private void InputWhit()
        {
            txtProductBar.BackColor = Color.White;
            txtProductBarcode.BackColor = Color.White;
            txtProductName.BackColor = Color.White;
            cmbCategory.BackColor = Color.White;
            cmbSupplier.BackColor = Color.White;
            txtStockCode.BackColor = Color.White;
            txtProductBrand.BackColor = Color.White;
            txtProductModel.BackColor = Color.White;
            txtProductMade.BackColor = Color.White;
            txtSerialNumber.BackColor = Color.White;
            txtTareWeight.BackColor = Color.White;
            txtNetWeight.BackColor = Color.White;
            txtTradePrice.BackColor = Color.White;
            txtRetailPrice.BackColor = Color.White;
            txtWholesale.BackColor = Color.White;
            cmbProductStatus.BackColor = Color.White;
            dkpDateRegister.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtProductBar.Enabled = true;
            txtProductBarcode.Enabled = true;
            txtProductName.Enabled = true;
            cmbCategory.Enabled = true;
            cmbSupplier.Enabled = true;
            txtStockCode.Enabled = true;
            txtProductBrand.Enabled = true;
            txtProductModel.Enabled = true;
            txtProductMade.Enabled = true;
            txtSerialNumber.Enabled = true;
            txtTareWeight.Enabled = true;
            txtNetWeight.Enabled = true;
            txtTradePrice.Enabled = true;
            txtRetailPrice.Enabled = true;
            txtWholesale.Enabled = true;
            cmbProductStatus.Enabled = true;
            dkpDateRegister.Enabled = true;
        }
        private void InputDisb()
        {
            txtProductBar.Enabled = false;
            txtProductBarcode.Enabled = false;
            txtProductName.Enabled = false;
            cmbCategory.Enabled = false;
            cmbSupplier.Enabled = false;
            txtStockCode.Enabled = false;
            txtProductBrand.Enabled = false;
            txtProductModel.Enabled = false;
            txtProductMade.Enabled = false;
            txtSerialNumber.Enabled = false;
            txtTareWeight.Enabled = false;
            txtNetWeight.Enabled = false;
            txtTradePrice.Enabled = false;
            txtRetailPrice.Enabled = false;
            txtWholesale.Enabled = false;
            cmbProductStatus.Enabled = false;
            dkpDateRegister.Enabled = false;
        }
        private void InputClea()
        {
            txtProductBar.Clear();
            txtProductBarcode.Clear();
            txtProductName.Clear();
            cmbCategory.Text = "";
            cmbSupplier.Text = "";
            txtStockCode.Clear();
            txtProductBrand.Clear();
            txtProductModel.Clear();
            txtProductMade.Clear();
            txtSerialNumber.Clear();
            txtTareWeight.Clear();
            txtNetWeight.Clear();
            cmbProductStatus.Text = "";
            txtTradePrice.Clear();
            txtRetailPrice.Clear();
            txtWholesale.Clear();
            imgProduct.Image = null;
            dkpDateRegister.Value = DateTime.Now.Date;
        }
        private void InputDimG() {
            txtProductBar.BackColor = Color.White;
            txtProductBarcode.BackColor = Color.DimGray;
            txtProductName.BackColor = Color.DimGray;
            cmbCategory.BackColor = Color.DimGray;
            cmbSupplier.BackColor = Color.DimGray;
            txtStockCode.BackColor = Color.DimGray;
            txtProductBrand.BackColor = Color.DimGray;
            txtProductModel.BackColor = Color.DimGray;
            txtProductMade.BackColor = Color.DimGray;
            txtSerialNumber.BackColor = Color.DimGray;
            txtTareWeight.BackColor = Color.DimGray;
            txtNetWeight.BackColor = Color.DimGray;
            txtTradePrice.BackColor = Color.DimGray;
            txtRetailPrice.BackColor = Color.DimGray;
            txtWholesale.BackColor = Color.DimGray;
            cmbProductStatus.BackColor = Color.DimGray;
            dkpDateRegister.BackColor = Color.DimGray;
            imgProduct.BackColor = Color.DimGray;
        }

        private void txtProductBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var barcode = txtProductBarcode.Text.Trim(' ');
                var que = VerifyCode(barcode);
                if (que == 0)
                {
                    InputManipulation.InputBoxLeave(txtProductBarcode, txtProductName, "Barcode",
                        Messages.TitleProducts);
                    txtProductBarcode.Enabled = true;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Product Barcode already exist!", Messages.InventorySystem);
                    txtProductBarcode.Focus();
                }
            }
        }

        private void txtProductBarcode_Leave(object sender, EventArgs e)
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
            //        PopupNotification.PopUpMessages(0, "Product Barcode already exist!", Messages.InventorySystem);
            //        txtCOD.Focus();
            //    }
            //}
            //else
            //    PopupNotification.PopUpMessages(0, "Product Barcode must not be empty!", Messages.InventorySystem);
            //txtCOD.Focus();
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtProductName, cmbCategory, "Product Name",
                Messages.TitleProducts);
            }
        }

        private void cmbCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(cmbCategory, cmbSupplier, "Product Category",
                Messages.TitleProducts);
            }
            if (e.KeyCode == Keys.F1)
            {
                BindCategory();
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_add || _edt)
            {
                var cat = cmbCategory.Text.Trim(' ');
            }
        }

        // Define the event handler method
        private void ComboBoxImageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedImageType = txtImageType.SelectedItem?.ToString();
        }

        private void cmbSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(cmbSupplier, txtStockCode, "Product Supplier",
                Messages.TitleProducts);
            }
            if (e.KeyCode == Keys.F1)
            {
                BindSupplier();
            }
        }

        private void txtStockCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtStockCode, txtProductBrand, "Stock Code",
                Messages.TitleProducts);
            }
        }

        private void txtProductBrand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtProductBrand, txtProductModel, "Product Brand",
                Messages.TitleProducts);
            }
        }

        private void txtProductModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtProductModel, txtProductMade, "Product Model",
                Messages.TitleProducts);
            }
        }

        private void txtProductMade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtProductMade, txtSerialNumber, "Product Made",
                Messages.TitleProducts);
            }
        }

        private void txtSerialNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtSerialNumber, txtTareWeight, "Serial Number",
                Messages.TitleProducts);
            }
        }

        private void txtTareWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtTareWeight.Text.Length;
                if (len > 0)
                {
                    txtTareWeight.BackColor = Color.White;
                    InputManipulation.InputBoxLeave(txtTareWeight, txtNetWeight, "Tare Weight",
                    Messages.TitleProducts);
                }
                else
                {
                    txtTareWeight.Text = @"0";
                    txtTareWeight.BackColor = Color.Yellow;
                    txtTareWeight.Focus();
                }
                if (txtTareWeight.Text == "0" && e.KeyCode == Keys.Enter)
                {
                    InputManipulation.InputBoxLeave(txtTareWeight, txtNetWeight, "Tare Weight",
                        Messages.TitleProducts);
                }
            }
        }

        private void txtTareWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtTareWeight.Focus();
                txtTareWeight.BackColor = Color.Yellow;
            }
            else
            {
                txtTareWeight.BackColor = Color.White;
            }
        }

        private void txtTareWeight_Leave(object sender, EventArgs e)
        {
            InputManipulation.DetectIntLeave(txtTareWeight);
        }

        private void txtNetWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtNetWeight.Text.Length;
                if (len > 0)
                {
                    txtNetWeight.BackColor = Color.White;
                    InputManipulation.InputBoxLeave(txtNetWeight, txtTradePrice, "Net Weight",
                    Messages.TitleProducts);
                }
                else
                {
                    txtNetWeight.Text = @"0";
                    txtNetWeight.BackColor = Color.Yellow;
                    txtNetWeight.Focus();
                }
                if (txtNetWeight.Text == "0" && e.KeyCode == Keys.Enter)
                {
                    InputManipulation.InputBoxLeave(txtNetWeight, txtTradePrice, "Net Weight",
                        Messages.TitleProducts);
                }
            }
        }

        private void txtNetWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtNetWeight.Focus();
                txtNetWeight.BackColor = Color.Yellow;
            }
            else
            {
                txtNetWeight.BackColor = Color.White;
            }
        }

        private void txtNetWeight_Leave(object sender, EventArgs e)
        {
            InputManipulation.DetectIntLeave(txtNetWeight);
        }

        private void txtTradePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtTradePrice.Text.Length;
                if (len > 0)
                {
                    txtTradePrice.BackColor = Color.White;
                    InputManipulation.InputBoxLeave(txtTradePrice, txtRetailPrice, "Trade Price",
                    Messages.TitleProducts);
                }
                else
                {
                    txtTradePrice.Text = @"0";
                    txtTradePrice.BackColor = Color.Yellow;
                    txtTradePrice.Focus();
                }
                if (txtTradePrice.Text == "0" && e.KeyCode == Keys.Enter)
                {
                    InputManipulation.InputBoxLeave(txtTradePrice, txtRetailPrice, "Trade Price",
                        Messages.TitleProducts);
                }
            }
        }

        private void txtTradePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtTradePrice.Focus();
                txtTradePrice.BackColor = Color.Yellow;
            }
            else
            {
                txtTradePrice.BackColor = Color.White;
            }
        }

        private void txtTradePrice_Leave(object sender, EventArgs e)
        {
            InputManipulation.DetectIntLeave(txtTradePrice);
        }

        private void txtRetailPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtRetailPrice.Text.Length;
                if (len > 0)
                {
                    txtRetailPrice.BackColor = Color.White;
                    InputManipulation.InputBoxLeave(txtRetailPrice, txtWholesale, "Retail Price",
                    Messages.TitleProducts);
                }
                else
                {
                    txtRetailPrice.Text = @"0";
                    txtRetailPrice.BackColor = Color.Yellow;
                    txtRetailPrice.Focus();
                }
                if (txtRetailPrice.Text == "0" && e.KeyCode == Keys.Enter)
                {
                    InputManipulation.InputBoxLeave(txtRetailPrice, txtWholesale, "Retail Price",
                        Messages.TitleProducts);
                }
            }
        }

        private void txtRetailPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtRetailPrice.Focus();
                txtRetailPrice.BackColor = Color.Yellow;
            }
            else
            {
                txtRetailPrice.BackColor = Color.White;
            }
        }

        private void txtRetailPrice_Leave(object sender, EventArgs e)
        {
            InputManipulation.DetectIntLeave(txtRetailPrice);
        }

        private void txtWholesale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtWholesale.Text.Length;
                if (len > 0)
                {
                    txtWholesale.BackColor = Color.White;
                    InputManipulation.InputBoxLeave(txtWholesale, cmbProductStatus, "Whole Sale Price",
                    Messages.TitleProducts);
                }
                else
                {
                    txtWholesale.Text = @"0";
                    txtWholesale.BackColor = Color.Yellow;
                    txtWholesale.Focus();
                }
                if (txtWholesale.Text == "0" && e.KeyCode == Keys.Enter)
                {
                    InputManipulation.InputBoxLeave(txtWholesale, cmbProductStatus, "Whole Sale Price",
                        Messages.TitleProducts);
                }
            }
        }

        private void txtWholesale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtWholesale.Focus();
                txtWholesale.BackColor = Color.Yellow;
            }
            else
            {
                txtWholesale.BackColor = Color.White;
            }
        }

        private void txtWholesale_Leave(object sender, EventArgs e)
        {
            InputManipulation.DetectIntLeave(txtWholesale);
        }

        private void cmbProductStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbProductStatus, dkpDateRegister, "Discontinued",
                Messages.TitleProducts);
            }
            if (e.KeyCode == Keys.F1)
            {
                BindStatus();
            }
        }


        private void dkpDateRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(dkpDateRegister, bntSave, "Date Register", Messages.TitleProducts);
            }
        }

        private void gridProduct_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gridProductList.RowCount <= 0) return;

            try
            {
                var view = sender as GridView;
                if (view == null) return;

                var idObj = view.GetFocusedRowCellValue("ID");
                if (idObj == null) return;

                var id = idObj.ToString();
                if (id.Length == 0) return;

                productId = int.Parse(id);
                var product = searchProductId(productId);

                if (product == null)
                {
                    PopupNotification.PopUpMessages(0, "Product Details", "No product found for this ID.");
                    return;
                }

                if (product.date_register == null)
                {
                    PopupNotification.PopUpMessages(0, "Product Details", "Date Registered is missing.");
                    return;
                }

                txtProductBar.Text = product.product_code ?? "";
                txtImageTitle.Text = product.product_name ?? "";
                txtProductBarcode.Text = product.product_code ?? "";
                txtProductName.Text = product.product_name ?? "";
                cmbCategory.Text = product.category_details ?? "";
                cmbSupplier.Text = product.supplier_name ?? "";
                txtStockCode.Text = product.stock_code ?? "";
                txtProductBrand.Text = product.brand ?? "";
                txtProductModel.Text = product.model ?? "";
                txtProductMade.Text = product.made ?? "";
                txtSerialNumber.Text = product.serial_number ?? "";
                txtTareWeight.Text = product.tare_weight.ToString(CultureInfo.InvariantCulture) ?? "0";
                txtNetWeight.Text = product.net_weight.ToString(CultureInfo.InvariantCulture) ?? "0";
                txtTradePrice.Text = product.trade_price.ToString(CultureInfo.InvariantCulture) ?? "0";
                txtRetailPrice.Text = product.retail_price.ToString(CultureInfo.InvariantCulture) ?? "0";
                txtWholesale.Text = product.wholesale.ToString(CultureInfo.InvariantCulture) ?? "0";
                cmbProductStatus.Text = product.status_details ?? "";
                dkpDateRegister.Value = product.date_register;

                var img = searchProductImg(product.product_code);
                var imgLocation = img?.img_location;

                if (string.IsNullOrEmpty(imgLocation))
                {
                    if (imgProduct != null) imgProduct.ImageLocation = ConstantUtils.defaultImgEmpty;
                    if (imgBigPreview != null) imgBigPreview.ImageLocation = ConstantUtils.defaultImgEmpty;
                }
                else
                {
                    var location = ConstantUtils.defaultImgLocation + imgLocation;
                    if (imgProduct != null) imgProduct.ImageLocation = location;
                    if (imgBigPreview != null) imgBigPreview.ImageLocation = location;
                }
            }
            catch (Exception ex)
            {
                PopupNotification.PopUpMessages(0, ex.Message, Messages.TableProduct);
            }
        }


        private void bindRefreshed() {
            listProducts = EnumerableUtils.getProductList();
            imgList = EnumerableUtils.getImgProductList();
            BindProductList();
        }

        private void BindProductList()
        {
            gridControl.Update();
            try
            {
                var list = listProducts.Select(x => new {
                    ID = x.product_id,
                    BARCODE = x.product_code,
                    ITEM = x.product_name,
                    CATEGORY = x.category_details,
                    SERIAL = x.serial_number,
                    TRADE = x.trade_price,
                    WHOLESALE = x.wholesale,
                    RETAIL = x.retail_price,
                    STATUS = x.status_details
                });

                //splash.ShowWaitForm();
                gridControl.DataBindings.Clear();
                gridControl.DataSource = list;


                gridProductList.Columns[0].Width = 40;
                gridProductList.Columns[1].Width = 90;
                gridProductList.Columns[2].Width = 290;
                gridProductList.Columns[3].Width = 100;
                gridProductList.Columns[4].Width = 100;
                //splash.CloseWaitForm();
            }
            catch (Exception ex)
            {
                gridControl.EndUpdate();
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
                cmbCategory.DataBindings.Clear();
                cmbCategory.DataSource = query;
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
                cmbProductStatus.DataBindings.Clear();
                cmbProductStatus.DataSource = query;
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
                cmbSupplier.DataBindings.Clear();
                cmbSupplier.DataSource = query;
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

        private ViewProducts searchProductId(int id)
        {
            return listProducts.FirstOrDefault(product => product.product_id == id);
        }

        private ViewImageProduct searchProductImg(string param)
        {
            return imgList.FirstOrDefault(img => img.image_code == param);
        }

        private string ExtractFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        private void GenerateCode()
        {
            var lastProductId = FetchUtils.getLastProductId();
            var alphaNumeric = new GenerateAlpaNum("P", 3, lastProductId);
            alphaNumeric.Increment();
            txtStockCode.Text = alphaNumeric.ToString();
        }

        private int VerifyCode(string barcode)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Products>(unWork);
                    var que = repository.FindBy(x => x.product_code == barcode);
                    return que.product_id;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return 0;
                }
            }
        }
        private string getfileExntesion(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        private void DataInsert()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk; 
                unWork.Begin();
                try
                {
                    var repository = new Repository<Products>(unWork);
                    var product = new Products()
                    {
                        product_code            = txtProductBarcode.Text.Trim(' '),
                        product_name            = txtProductName.Text.Trim(' '),
                        category_id      = GetCategoryId(cmbCategory.Text),
                        supplier_id      = GetSupplierId(cmbSupplier.Text),
                        stock_code       = txtStockCode.Text.Trim(' '),
                        brand           = txtProductBrand.Text.Trim(' '),
                        model           = txtProductModel.Text.Trim(' '),
                        made            = txtProductMade.Text.Trim(' '),
                        serial_number          = txtSerialNumber.Text.Trim(' '),
                        tare_weight      = Convert.ToDecimal(txtTareWeight.Text),
                        net_weight       = Convert.ToDecimal(txtNetWeight.Text),
                        trade_price      = Convert.ToDecimal(txtTradePrice.Text),
                        retail_price     = Convert.ToDecimal(txtRetailPrice.Text),
                        wholesale       = Convert.ToDecimal(txtWholesale.Text), 
                        status_id        = GetStatusId(cmbProductStatus.Text),
                        date_register        = dkpDateRegister.Value.Date
                    };
                    var result = repository.Add(product);
                    if (result > 0)
                    {
                        PopupNotification.PopUpMessages(1,
                            "Product Name: " + txtProductName.Text.Trim(' ') + " " + Messages.SuccessInsert,
                            Messages.TitleSuccessInsert);
                        unWork.Commit();
                        bindRefreshed();
                    }
                    else
                    {
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
                    var repository = new Repository<Products>(unWork);
                    var que = repository.Id(productId);
                    que.product_code = txtProductBarcode.Text.Trim(' ');
                    que.product_name = txtProductName.Text.Trim(' ');
                    que.category_id = GetCategoryId(cmbCategory.Text);
                    que.supplier_id = GetSupplierId(cmbSupplier.Text);
                    que.stock_code = txtStockCode.Text.Trim(' ');
                    que.brand = txtProductBrand.Text.Trim(' ');
                    que.model = txtProductModel.Text.Trim(' ');
                    que.made = txtProductMade.Text.Trim(' ');
                    que.serial_number = txtSerialNumber.Text.Trim(' ');
                    que.tare_weight = Convert.ToDecimal(txtTareWeight.Text);
                    que.net_weight = Convert.ToDecimal(txtNetWeight.Text);
                    que.trade_price = Convert.ToDecimal(txtTradePrice.Text);
                    que.retail_price = Convert.ToDecimal(txtRetailPrice.Text);
                    que.wholesale = Convert.ToDecimal(txtWholesale.Text);
                    que.status_id = GetStatusId(cmbProductStatus.Text);
                    que.date_register = dkpDateRegister.Value.Date;
                    var result = repository.Update(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, "Product Name: " + txtProductName.Text.Trim(' ') + " " + Messages.SuccessUpdate,
                         Messages.TitleSuccessUpdate);
                        unWork.Commit();
                        bindRefreshed();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedUpdate);

                }
            }
        }

        private void XtraEmployee_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == xtraTabImage && e.PrevPage == XtrPerProfile)
            {
                _add = false;
                _edt = false;
                _del = false;

                bntAdd.Enabled = false;
                bntUpdate.Enabled = false;
                bntDelete.Enabled = false;
                bntSave.Enabled = false;
                bntClear.Enabled = false;
                bntCancel.Enabled = false;
            }

            if (e.Page == XtrPerProfile && e.PrevPage == xtraTabImage)
            {
                txtImageFilename.Text = string.Empty;
                imgBigPreview.Image = null;
                bntAdd.Enabled = true;
                bntUpdate.Enabled = true;
                bntDelete.Enabled = true;
                bntSave.Enabled = false;
                bntClear.Enabled = false;
                bntCancel.Enabled = true;
            }

            if (e.Page == XtrPerProfile)
            {
                try
                {
                    if (imgBigPreview.Image != null)
                    {
                        imgBigPreview.Image.Dispose();
                        imgBigPreview.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error disposing image: " + ex.Message);
                }

                bindRefreshed();
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
                    var productName = txtProductName.Text.Trim();

                    var productId = FetchUtils.getProductId(productName);

                    if (productId == 0)
                    {
                        PopupNotification.PopUpMessages(0, "Product not found: " + productName, Messages.TitleFialedDelete);
                        return;
                    }

                    var productRepository = new Repository<Products>(unWork);
                    var product = productRepository.Id(productId);

                    if (product == null)
                    {
                        PopupNotification.PopUpMessages(0, "Product not found for deletion: " + productName, Messages.TitleFialedDelete);
                        return;
                    }

                    // Use the productName as the image title to fetch image id
                    var imageId = FetchUtils.getImageId(productName);

                    var imageRepository = new Repository<ProductImages>(unWork);

                    ProductImages productImage = null;
                    if (imageId != 0)
                    {
                        productImage = imageRepository.Id(imageId);
                    }

                    // Delete product image if found
                    bool imageDeleted = true;
                    if (productImage != null)
                    {
                        imageDeleted = imageRepository.Delete(productImage);
                    }

                    var productDeleted = productRepository.Delete(product);

                    if (productDeleted && imageDeleted)
                    {
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, $"Product '{productName}' and its image deleted successfully.", Messages.TitleSuccessDelete);
                        bindRefreshed();
                    }
                    else
                    {
                        unWork.Rollback();
                        PopupNotification.PopUpMessages(0, $"Failed to delete product or its image: {productName}", Messages.TitleFialedDelete);
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedDelete);
                }
            }
        }

        private int saveProductImage()
        {
            var returnValue = 0;
            using (var session = new DalSession())
            {
                var unitWorks = session.UnitofWrk;
                unitWorks.Begin();
                try
                {
                    var filePathLocation = txtImageFilename.Text.Trim(' ');
                    var filePath = ExtractFileName(filePathLocation);
                    var repository = new Repository<ProductImages>(unitWorks);
                    var imageCode = txtProductBar.Text.Trim(' ');

                    var existingImg = repository.FindBy(x => x.image_code == imageCode);

                    if (existingImg != null)
                    {
                        existingImg.title = txtImageTitle.Text.Trim(' ');
                        existingImg.img_type = txtImageType.Text.Trim(' ');
                        existingImg.img_location = filePath;
                        existingImg.branch_id = 1;

                        var updated = repository.Update(existingImg);
                        if (updated)
                        {
                            PopupNotification.PopUpMessages(1, "Product image updated: " + txtProductName.Text.Trim(' ') + " " + Messages.SuccessUpdate,
                                Messages.TitleSuccessUpdate);
                            unitWorks.Commit();
                            returnValue = 1;
                        }
                    }
                    else
                    {
                        var img = new ProductImages()
                        {
                            image_code = imageCode,
                            title = txtImageTitle.Text.Trim(' '),
                            img_type = txtImageType.Text.Trim(' '),
                            img_location = filePath,
                            branch_id = 1
                        };
                        var result = repository.Add(img);
                        if (result > 0)
                        {
                            PopupNotification.PopUpMessages(1, "Product image added: " + txtProductName.Text.Trim(' ') + " " + Messages.SuccessInsert,
                                Messages.TitleSuccessInsert);
                            unitWorks.Commit();
                            returnValue = 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    unitWorks.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFailedInsert);
                    returnValue = 0;
                }
            }
            return returnValue;
        }
    }
}
