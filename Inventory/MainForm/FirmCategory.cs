using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Inventory.Config;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using Query = ServeAll.Core.Queries.Query;


namespace Inventory.MainForm
{
    public partial class FirmCategory : Form
    {
        private FirmMain _main;
        private bool _add, _edt, _del, _img, _cat, _sup;
        private readonly int _userId;
        private readonly int _userTyp;
        private IEnumerable<ViewCategory> listCategory;
        private IEnumerable<ViewSupplier> listSupplier;
        private string _title, _type, _location, _code;
        private int _imgHeight, _imgWidth;

        public FirmMain Main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FirmCategory(int userId, int userTy)
        {
            _userId = userId;
            _userTyp = userTy;

            var allowedRoles = new List<int> { 1, 2 }; // Admin and User

            if (!allowedRoles.Contains(_userTyp))
            {
                PopupNotification.PopUpMessages(0, Messages.AdminPrivilege, Messages.InventorySystem);

                this.DialogResult = DialogResult.Cancel;
                return;
            }

            InitializeComponent();
            this.DialogResult = DialogResult.OK;
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            bindRefreshedCategory();
            bindRefreshedSupplier();
            XtraControl_SelectedPageChanged(xtraControl, null);
        }
        private void Options_Tick(object sender, EventArgs e)
        {
            PanelInterface.OptionTick(this, pnlOptions);
        }

        private void RightOptions_Tick(object sender, EventArgs e)
        {
            PanelInterface.RightOptionTick(this, pnlRightOptions);
        }

        private void FrmCategory_MouseMove(object sender, MouseEventArgs e)
        {
            PanelInterface.MouseMOve(this, pnlRightOptions, e);
        }

        private void pbHome_Click(object sender, EventArgs e)
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

        private void pbExit_Click(object sender, EventArgs e)
        {
            PopupNotification.PopUpMessageExit();
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

        private void InputWhit()
        {
            txtCategoryId.BackColor = Color.White;
            txtCategoryCode.BackColor = Color.White;
            txtCategoryDetails.BackColor = Color.White;
            dkpDateRegister.BackColor = Color.White;
        }
        private void InputWhitSup()
        {
            txtSupplierId.BackColor = Color.White;
            txtSupplierCode.BackColor = Color.White;
            txtSupplierName.BackColor = Color.White;
            cmbGender.BackColor = Color.White;
            txtBarangay.BackColor = Color.White;
            txtCity.BackColor = Color.White;
            txtProvince.BackColor = Color.White;
            txtZipCode.BackColor = Color.White;
            txtContactPerson.BackColor = Color.White;
            txtTelephone.BackColor = Color.White;
            txtMobile.BackColor = Color.White;
            txtEmail.BackColor = Color.White;
            txtCompanyType.BackColor = Color.White;
            txtWeb.BackColor = Color.White;
            dkpSupplier.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtCategoryId.Enabled = false;
            txtCategoryCode.Enabled = true;
            txtCategoryDetails.Enabled = true;
            dkpDateRegister.Enabled = true;
        }
        private void InputEnabSup()
        {
            txtSupplierId.Enabled = false;
            txtSupplierCode.Enabled = true;
            txtSupplierName.Enabled = true;
            cmbGender.Enabled = true;
            txtBarangay.Enabled = true;
            txtCity.Enabled = true;
            txtProvince.Enabled = true;
            txtZipCode.Enabled = true;
            txtContactPerson.Enabled = true;
            txtTelephone.Enabled = true;
            txtMobile.Enabled = true;
            txtEmail.Enabled = true;
            txtWeb.Enabled = true;
            txtCompanyType.Enabled = true;
            dkpSupplier.Enabled = true;
        }
        private void InputDisb()
        {
            txtCategoryId.Enabled = false;
            txtCategoryCode.Enabled = false;
            txtCategoryDetails.Enabled = false;
            dkpDateRegister.Enabled = false;
        }
        private void InputDisbSup()
        {
            txtSupplierId.Enabled = false;
            txtSupplierCode.Enabled = false;
            txtSupplierName.Enabled = false;
            cmbGender.Enabled = false;
            txtBarangay.Enabled = false;
            txtCity.Enabled = false;
            txtProvince.Enabled = false;
            txtZipCode.Enabled = false;
            txtContactPerson.Enabled = false;
            txtTelephone.Enabled = false;
            txtMobile.Enabled = false;
            txtEmail.Enabled = false;
            txtWeb.Enabled = false;
            txtCompanyType.Enabled = false;
            dkpSupplier.Enabled = false;
        }
        private void InputClea()
        {
            if (!_add == false)
            {
                txtCategoryCode.Clear();
                txtSupplierCode.Clear();
            }
            txtCategoryDetails.Clear();
        }
        private void InputClearSup()
        {
            txtSupplierName.Clear();
            txtBarangay.Clear();
            txtCity.Clear();
            txtProvince.Clear();
            txtZipCode.Clear();
            txtContactPerson.Clear();
            txtTelephone.Clear();
            txtMobile.Clear();
            txtEmail.Clear();
            txtCompanyType.Clear();
            cmbGender.Text = "";
        }
        private void InputDimG()
        {
            txtCategoryId.BackColor = Color.DimGray;
            txtCategoryCode.BackColor = Color.DimGray;
            txtCategoryDetails.BackColor = Color.DimGray;
            dkpDateRegister.BackColor = Color.DimGray;
        }
        private void InputDimGSup()
        {
            txtSupplierId.BackColor = Color.DimGray;
            txtSupplierCode.BackColor = Color.DimGray;
            txtSupplierName.BackColor = Color.DimGray;
            cmbGender.BackColor = Color.DimGray;
            txtBarangay.BackColor = Color.DimGray;
            txtCity.BackColor = Color.DimGray;
            txtProvince.BackColor = Color.DimGray;
            txtZipCode.BackColor = Color.DimGray;
            txtContactPerson.BackColor = Color.DimGray;
            txtTelephone.BackColor = Color.DimGray;
            txtMobile.BackColor = Color.DimGray;
            txtEmail.BackColor = Color.DimGray;
            txtWeb.BackColor = Color.DimGray;
            txtCompanyType.BackColor = Color.DimGray;
            dkpSupplier.BackColor = Color.DimGray;
        }

        private void GenerateCode()
        {
            var lastCategoryId = FetchUtils.getLastCategoryId();
            var alphaNumeric = new GenerateAlpaNum("CAT", 3, lastCategoryId);
            alphaNumeric.Increment();
            txtCategoryCode.Text = alphaNumeric.ToString();
        }
        private void GenerateSupCode()
        {
            var lastSupplierId = FetchUtils.getLastSupplierId();
            var alphaNumeric = new GenerateAlpaNum("SUP", 3, lastSupplierId);
            alphaNumeric.Increment();
            txtSupplierCode.Text = alphaNumeric.ToString();
        }

        private void GenerateNewCategoryId()
        {
            int lastId = FetchUtils.getLastCategoryId();
            int newId = lastId + 1;

            txtCategoryId.Text = newId.ToString();
        }

        private void GenerateNewSupplierId()
        {
            int lastId = FetchUtils.getLastSupplierId();
            int newId = lastId + 1;

            txtSupplierId.Text = newId.ToString();
        }

        private void ButAdd()
        {
            ButtonAdd();
            _add = true;
            _edt = false;
            _del = false;
            gridControl.Enabled = false;
            gridCtrlSupplier.Enabled = false;
            InputClearSup();
            if (_cat && _sup == false)
            {
                InputEnab();
                InputWhit();
                InputClea();
                txtCategoryDetails.Focus();
                GenerateCode();
                GenerateNewCategoryId();
            }
            if (_cat == false && _sup )
            {
                InputEnabSup();
                InputWhitSup();
                InputClearSup();
                txtSupplierName.Focus();
                GenerateSupCode();
                GenerateNewSupplierId();
            }
        }
        private void ButUpd()
        {
            ButtonUpd();
            _add = false;
            _edt = true;
            _del = false;
            if (_cat && _sup == false)
            {
                InputEnab();
                InputWhit();
                gridControl.Enabled = false;
                txtCategoryDetails.Focus();
            }
            else if (_cat == false && _sup)
            {
                InputEnabSup();
                InputWhitSup();
                gridCtrlSupplier.Enabled = false;
                txtSupplierName.Focus();
            }
        }
        private void ButDel()
        {
            ButtonDel();
            InputDisb();
            InputWhit();
            InputWhitSup();
            InputDisbSup();
            _add = false;
            _edt = false;
            _del = true;
            gridControl.Enabled = false;
            gridCtrlSupplier.Enabled = false;
        }
        private void ButClr()
        {
            bindRefreshedCategory();
            bindRefreshedSupplier();
            ButtonClr();
            InputWhit();
            InputDisb();
            InputWhitSup();
            InputDisbSup();
            InputClea();
            InputClearSup();
            gridControl.Enabled = true;
            gridCtrlSupplier.Enabled = true;
            if (_cat && _sup == false)
            {
                int focusedRowHandle = gridCategory.FocusedRowHandle;
                if (focusedRowHandle >= 0)
                {
                    gridCategory_FocusedRowChanged(
                        gridCategory,
                        new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(
                            focusedRowHandle,
                            focusedRowHandle
                        )
                    );
                }
            }
            else if (_cat == false && _sup)
            {
                int focusedRowHandle = gridSupplier.FocusedRowHandle;
                if (focusedRowHandle >= 0)
                {
                    GridSupplier_FocusedRowChanged(
                        gridSupplier,
                        new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(
                            focusedRowHandle,
                            focusedRowHandle
                        )
                    );
                }
            }
        }
        private void ButSav()
        {
            SavCat();
        }
        private void ButCan()
        {
            ButtonCan();
            InputDisb();
            InputDimG();
            InputClea();
            InputClearSup();
            InputDisbSup();
            InputDimGSup();
            gridControl.Enabled = true;
            gridCtrlSupplier.Enabled = true;
        }

        private void SavCat()
        {
            if (_add && _edt == false && _del == false && _sup == false)
            {
                DataInsert();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
            }
            if (_add == false && _edt && _del == false && _sup == false)
            {
                DataUpdate();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
            }
            if (_add == false && _edt == false && _del && _sup == false)
            {
                DataDelete();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
            }
            if (_add && _edt == false && _del == false && _cat == false)
            {
                DataInsertSup();
                ButtonSav();
                InputDisbSup();
                InputDimGSup();
                InputClearSup();
            }
            if (_add == false && _edt && _del == false && _cat == false)
            {
                DataUpdateSup();
                ButtonSav();
                InputDisbSup();
                InputDimGSup();
                InputClearSup();
            }
            if (_add == false && _edt == false && _del && _cat == false)
            {
                DataDeleteSup();
                ButtonSav();
                InputDisbSup();
                InputDimGSup();
                InputClearSup();
            }
            _add = false;
            _edt = false;
            _del = false;
            gridControl.Enabled = true;
            bindRefreshedCategory();
            bindRefreshedSupplier();
        }

        private void bindRefreshedCategory()
        {
            listCategory = EnumerableUtils.getCategoryList();
            BindCategoryList();
        }
        private void bindRefreshedSupplier()
        {
            listSupplier = EnumerableUtils.getSupplierList();
            BindSupplierList();
            BindCompany();
            BindContact();
            BindAddress();
        }

        private void BindCategoryList()
        {
            gridControl.Update();
            try
            {
                var listCat = listCategory.Select(x => new {
                    ID = x.category_id,
                    CODE = x.category_code,
                    CATEGORY = x.category_details,
                    DATE = x.date_register.ToString("MM/dd/yyyy")
                });

                gridControl.DataBindings.Clear();
                gridControl.DataSource = listCat;
                gridCategory.Columns[0].Width = 40;
                gridCategory.Columns[1].Width = 90;
                gridCategory.Columns[2].Width = 250;
                gridCategory.Columns[3].Width = 100;
            }
            catch (Exception ex)
            {
                gridControl.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableSupplier);
            }
        }
        private void BindSupplierList()
        {
            gridCtrlSupplier.Update();
            try
            {
                var listSup = listSupplier.Select(x => new {
                    ID = x.supplier_id,
                    CODE = x.supplier_code,
                    SUPPLIER = x.supplier_name,
                    COMPANY = x.company_name,
                    EMAIL = x.email_address,
                    GENDER = x.gender,
                    TELEPHONE = x.telephone_number,
                    MOBILE = x.mobile_number,
                    ADDRESS = $"{x.street}, {x.barangay}, {x.province}",
                    DATE = x.date_register.ToString("MM/dd/yyyy")
                });

                gridCtrlSupplier.DataBindings.Clear();
                gridCtrlSupplier.DataSource = listSup;
                gridSupplier.Columns[0].Width = 40;
                gridSupplier.Columns[1].Width = 90;
                gridSupplier.Columns[2].Width = 250;
                gridSupplier.Columns[3].Width = 100;
                gridSupplier.Columns[4].Width = 100;
                gridSupplier.Columns[5].Width = 90;
                gridSupplier.Columns[6].Width = 100;
                gridSupplier.Columns[7].Width = 100;
                gridSupplier.Columns[8].Width = 120;
                gridSupplier.Columns[9].Width = 100;

            }
            catch (Exception ex)
            {
                gridControl.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableSupplier);
            }
        }
        private void BindContact()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Contact>(unWork);
                var query = repository.SelectAll(Query.AllContact).Select(x => x.mobile_number).Distinct().ToList();
            }
        }

        private void BindAddress()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Address>(unWork);
                var query = repository.SelectAll(Query.AllAddress)
                            .Select(x => $"{x.street}, {x.barangay}, {x.city}, {x.province}")
                            .Distinct()
                            .OrderBy(addr => addr)
                            .ToList();
            }
        }

        private void BindCompany()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<ViewCompany>(unWork);
                var query = repository.SelectAll(Query.AllCompany).Select(x => x.company_name).Distinct().ToList();
            }
        }
        private void dkpREG_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(dkpDateRegister, bntSave, "Date Register", Messages.TitleCategory);
        }

        private void dkpREG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(dkpDateRegister, bntSave, "Date Register", Messages.TitleCategory);
            }
        }

        private ViewCategory searchCategoryId(int id)
        {
            return listCategory.FirstOrDefault(view_category => view_category.category_id == id);
        }
        private ViewSupplier searchSupplierId(int id)
        {
            return listSupplier.FirstOrDefault(view_supplier => view_supplier.supplier_id == id);
        }

        private void gridCategory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridCategory.RowCount > 0)
            {
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("ID").ToString();
                    if (id.Length > 0)
                    {
                        var category_id = int.Parse(id);
                        var category = searchCategoryId(category_id);
                        var categoryCode = category.category_code;
                        int categoryId = category.category_id;
                        txtCategoryId.Text = categoryId.ToString();
                        txtCategoryCode.Text = categoryCode;
                        txtCategoryDetails.Text = category.category_details;
                        dkpDateRegister.Format = DateTimePickerFormat.Custom;
                        dkpDateRegister.CustomFormat = "MM/dd/yyyy";
                        dkpDateRegister.Value = category.date_register;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void GridSupplier_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridSupplier.RowCount > 0)
            {
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("ID").ToString();
                    if (id.Length > 0)
                    {
                        var supplier_id = int.Parse(id);
                        var supplier = searchSupplierId(supplier_id);
                        var supplierCode = supplier.supplier_code;
                        int supplierId = supplier.supplier_id;
                        txtSupplierId.Text = supplierId.ToString();
                        txtSupplierCode.Text = supplierCode;
                        txtSupplierName.Text = supplier.supplier_name;
                        cmbGender.Text = supplier.gender;
                        txtBarangay.Text = supplier.barangay;
                        txtCity.Text = supplier.street;      
                        txtZipCode.Text = supplier.zip_code.ToString();
                        txtProvince.Text = supplier.province;
                        txtContactPerson.Text = supplier.contact_name;
                        txtTelephone.Text = supplier.telephone_number;
                        txtMobile.Text = supplier.mobile_number;
                        txtEmail.Text = supplier.email_address;
                        txtWeb.Text = supplier.web;
                        txtCompanyType.Text = supplier.company_type;
                        dkpDateRegister.Format = DateTimePickerFormat.Custom;
                        dkpDateRegister.CustomFormat = "MM/dd/yyyy";
                        dkpDateRegister.Value = supplier.date_register;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void gridCategory_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhit();
            bntCancel.Enabled = true;
        }

        private void gridCategory_LostFocus(object sender, EventArgs e)
        {
            InputDimG();
        }
        private void GridSupplier_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhitSup();
            bntCancel.Enabled = true;
        }

        private void GridSupplier_LostFocus(object sender, EventArgs e)
        {
            InputDimGSup();
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

        private void XtraControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraControl.SelectedTabPage == xtraCategory)
            {
                _cat = true;
                _sup = false;
                lblMainTitle.Text = "Category";
            }
            else if (xtraControl.SelectedTabPage == xtraSupplierTab)
            {
                _sup = true;
                _cat = false;
                lblMainTitle.Text = "Supplier";
            }
        }

        private void TxtCategoryDetails_KeyDown_1(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    InputManipulation.InputBoxLeave(txtCategoryDetails, dkpDateRegister, "Category Details", Messages.TitleCategory);
                }
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            ButCan();
        }

        private void TxtSupplierName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtSupplierName, cmbGender, "Supplier Name",
                Messages.TitleSupplier);
            }
        }

        private void CmbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbGender, txtBarangay, "Supplier Name",
                Messages.TitleSupplier);
            }
        }

        private void DkpSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(dkpSupplier, bntSave, "Supplier Date",
                Messages.TitleSupplier);
            }
        }

        private void TxtCategoryCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtCategoryCode, txtCategoryDetails, "Category Code",
                Messages.TitleSupplier);
            }
        }

        private void bntClear_Click(object sender, EventArgs e)
        {
            ButClr();
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            if (_cat && _sup == false)
            {
                InputWhit();
                var que =
                    PopupNotification.PopUpMessageQuestion(
                        "Are you sure you want to Delete Category: " + txtCategoryDetails.Text.Trim(' ') + " " + "?", "Category Details");
                if (que)
                {
                    ButDel();
                    gridControl.Enabled = false;
                }
                else
                {
                    ButCan();
                    gridControl.Enabled = true;
                }
            }
            if (_cat == false && _sup )
            {
                InputWhitSup();
                var que =
                    PopupNotification.PopUpMessageQuestion(
                        "Are you sure you want to Delete Supplier: " + txtSupplierName.Text.Trim(' ') + " " + "?", "Supplier Details");
                if (que)
                {
                    ButDel();
                    gridControl.Enabled = false;
                }
                else
                {
                    ButCan();
                    gridControl.Enabled = true;
                }
            }
        }

        private void bntHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }

        private void DataInsert()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Category>(unWork);
                    var category = new Category()
                    {
                        category_code = txtCategoryCode.Text.Trim(' '),
                        category_details = txtCategoryDetails.Text.Trim(' '),
                        date_register = dkpDateRegister.Value.Date
                    };
                    var result = repository.Add(category);
                    if (result > 0)
                    {
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Category Code: " +
                                                           txtCategoryCode.Text.Trim(' ')
                                                           + " " + Messages.SuccessInsert,
                            Messages.TitleSuccessInsert);
                        bindRefreshedCategory();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFailedInsert);
                }
            }
        }
        private string GetGenerateContactCode()
        {
            var lastContactId = FetchUtils.getLastContactId();
            var alphaNumeric = new GenerateAlpaNum("C", 3, lastContactId);
            alphaNumeric.Increment();
            return alphaNumeric.ToString();
        }

        private string GetGenerateCompanyCode()
        {
            var lastCompanyId = FetchUtils.getLastCompanyId();
            var alphaNumeric = new GenerateAlpaNum("COMP", 3, lastCompanyId);
            alphaNumeric.Increment();
            return alphaNumeric.ToString();
        }

        private void DataInsertSup()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    // 1. Add Contact
                    var contact = new Contact
                    {
                        contact_code = GetGenerateContactCode(),
                        contact_name = txtContactPerson.Text.Trim(),
                        position = "Supervisor/Authorized Person",
                        telephone_number = txtTelephone.Text.Trim(),
                        mobile_number = txtMobile.Text.Trim(),
                        mobile_secondary = txtMobile.Text.Trim(),
                        email_address = txtEmail.Text.Trim(),
                        web_url = txtWeb.Text.Trim(),
                        fax_number = null,
                        date_register = DateTime.Now
                    };
                    var contactRepo = new Repository<Contact>(unWork);
                    var contactId = (int)contactRepo.Add(contact);

                    // 2. Add Address
                    var address = new Address
                    {
                        street = null,
                        barangay = txtBarangay.Text.Trim(),
                        city = txtCity.Text.Trim(),
                        province = txtProvince.Text.Trim(),
                        zip_code = int.TryParse(txtZipCode.Text.Trim(), out var zip) ? zip.ToString() : "0",
                        country = "Philippines"
                    };
                    var addressRepo = new Repository<Address>(unWork);
                    var addressId = (int)addressRepo.Add(address);

                    // 3. Add Company
                    var company = new Company
                    {
                        company_code = GetGenerateCompanyCode(),
                        company_name = txtSupplierName.Text.Trim(),
                        company_type = txtCompanyType.Text.Trim(),
                        date_register = DateTime.Now,
                        address_id = addressId,
                        contact_id = contactId
                    };
                    var companyRepo = new Repository<Company>(unWork);
                    var companyId = (int)companyRepo.Add(company);

                    // 4. Add Supplier
                    var supplier = new Supplier
                    {
                        supplier_code = txtSupplierCode.Text.Trim(),
                        supplier_name = txtSupplierName.Text.Trim(),
                        gender = cmbGender.Text.Trim(),
                        contact_id = contactId,
                        address_id = addressId,
                        company_id = companyId,
                        date_register = dkpSupplier.Value.Date
                    };
                    var supplierRepo = new Repository<Supplier>(unWork);
                    var result = (int)supplierRepo.Add(supplier);

                    if (result > 0)
                    {
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Supplier: " + supplier.supplier_name + " added successfully!", "Success");
                        bindRefreshedSupplier();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.Message, "Insert Failed");
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
                    var catId = Convert.ToInt32(txtCategoryId.Text);
                    var repository = new Repository<Category>(unWork);
                    var que = repository.Id(catId);

                    que.category_code = txtCategoryCode.Text.Trim(' ');
                    que.category_details = txtCategoryDetails.Text.Trim(' ');
                    que.date_register = dkpDateRegister.Value.Date;
                    var result = repository.Update(que);
                    if (result)
                    {
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Category Code: " +
                                                           txtCategoryCode.Text.Trim(' ')
                                                           + " " + Messages.SuccessUpdate,
                            Messages.TitleSuccessUpdate);
                        bindRefreshedCategory();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedUpdate);
                }
            }
        }

        private void DataUpdateSup()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    if (!int.TryParse(txtSupplierId.Text, out int supplierId) || supplierId <= 0)
                    {
                        PopupNotification.PopUpMessages(0, "Invalid supplier ID.", Messages.TitleFialedUpdate);
                        return;
                    }

                    var supplierRepo = new Repository<Supplier>(unWork);
                    var supplier = supplierRepo.Id(supplierId);
                    if (supplier == null)
                    {
                        PopupNotification.PopUpMessages(0, "Supplier not found.", Messages.TitleFialedUpdate);
                        return;
                    }

                    // === Update Contact ===
                    var contactRepo = new Repository<Contact>(unWork);
                    var contact = contactRepo.Id(supplier.contact_id);
                    if (contact != null)
                    {
                        contact.contact_name = txtSupplierName.Text.Trim();
                        contact.position = "Supervisor/Authorized Person";
                        contact.telephone_number = txtTelephone.Text.Trim();
                        contact.mobile_number = txtMobile.Text.Trim();
                        contact.mobile_secondary = txtMobile.Text.Trim();
                        contact.email_address = txtEmail.Text.Trim();
                        contact.web_url = txtWeb.Text.Trim();
                        contact.date_register = DateTime.Now;
                        contactRepo.Update(contact);
                    }

                    // === Update Address ===
                    var addressRepo = new Repository<Address>(unWork);
                    var address = addressRepo.Id(supplier.address_id);
                    if (address != null)
                    {
                        address.barangay = txtBarangay.Text.Trim();
                        address.city = txtCity.Text.Trim();
                        address.province = txtProvince.Text.Trim();
                        address.zip_code = int.TryParse(txtZipCode.Text.Trim(), out var zip) ? zip.ToString() : "0";
                        address.country = "Philippines";
                        addressRepo.Update(address);
                    }

                    // === Update Company ===
                    var companyRepo = new Repository<Company>(unWork);
                    var company = companyRepo.Id(supplier.company_id);
                    if (company != null)
                    {
                        company.company_name = txtSupplierName.Text.Trim();
                        company.company_type = txtCompanyType.Text.Trim();
                        company.date_register = DateTime.Now;
                        companyRepo.Update(company);
                    }

                    // === Update Supplier ===
                    supplier.supplier_code = txtSupplierCode.Text.Trim();
                    supplier.supplier_name = txtSupplierName.Text.Trim();
                    supplier.gender = cmbGender.Text.Trim();
                    supplier.date_register = dkpSupplier.Checked ? dkpSupplier.Value.Date : supplier.date_register;

                    var result = supplierRepo.Update(supplier);

                    if (result)
                    {
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, $"Supplier: {supplier.supplier_name} successfully updated!", Messages.TitleSuccessUpdate);
                        bindRefreshedSupplier();
                    }
                    else
                    {
                        unWork.Rollback();
                        PopupNotification.PopUpMessages(0, "Update failed. Please check the input.", Messages.TitleFialedUpdate);
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, $"Update failed due to an error: {ex.Message}", Messages.TitleFialedUpdate);
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
                    var catId = Convert.ToInt32(txtCategoryId.Text);
                    var repository = new Repository<Category>(unWork);
                    var que = repository.Id(catId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Category Code: " +
                                                           txtCategoryCode.Text.Trim(' ')
                                                           + " " + Messages.SuccessDelete,
                            Messages.TitleSuccessDelete);
                        bindRefreshedCategory();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedDelete);
                }
            }
        }
        private void DataDeleteSup()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();

                try
                {
                    if (!int.TryParse(txtSupplierId.Text.Trim(), out var supplierId) || supplierId <= 0)
                    {
                        PopupNotification.PopUpMessages(0, "Invalid Supplier ID.", Messages.TitleFialedDelete);
                        return;
                    }

                    var supplierRepo = new Repository<Supplier>(unWork);
                    var supplier = supplierRepo.Id(supplierId);

                    if (supplier == null)
                    {
                        PopupNotification.PopUpMessages(0, "Supplier not found.", Messages.TitleFialedDelete);
                        unWork.Rollback();
                        return;
                    }

                    // Repositories for related tables
                    var addressRepo = new Repository<Address>(unWork);
                    var contactRepo = new Repository<Contact>(unWork);
                    var companyRepo = new Repository<Company>(unWork);

                    // Load related entities manually using their IDs
                    var address = addressRepo.Id(supplier.address_id);
                    var contact = contactRepo.Id(supplier.contact_id);
                    var company = companyRepo.Id(supplier.company_id);

                    // Delete Supplier first (or last if you have ON DELETE CASCADE configured)
                    var supplierDeleted = supplierRepo.Delete(supplier);

                    // Delete related entities only if they exist
                    if (address != null)
                        addressRepo.Delete(address);

                    if (contact != null)
                        contactRepo.Delete(contact);

                    if (company != null)
                        companyRepo.Delete(company);

                    unWork.Commit();

                    PopupNotification.PopUpMessages(1,
                        $"Supplier: {txtSupplierName.Text.Trim()} {Messages.SuccessDelete}",
                        Messages.TitleSuccessDelete);

                    bindRefreshedSupplier();
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, $"Deletion failed: {ex.Message}", Messages.TitleFialedDelete);
                }
            }
        }

    }
}
