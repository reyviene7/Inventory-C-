using System;
using System.Collections.Generic;
using System.Drawing;
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
    public partial class FirmCategory : Form
    {
        private FirmMain _main;
        private bool _add, _edt, _del, _img, _cat;
        
        private string _title, _type, _location, _code;
        private int _imgHeight, _imgWidth;

        public FirmMain Main
        {
            get { return _main; }
            set { _main = value; }
        }


        public FirmCategory()
        {
            InitializeComponent();
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            BindCategoryList();
            BindImageList();
            _cat = true;
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
            if (_cat && _img == false)
            {
                InputWhit();
                var que =
                    PopupNotification.PopUpMessageQuestion(
                        "Are you sure you want to Delete Category Code: " + txtCOD.Text.Trim(' ') + " " + "?", "Category Details");
                if (que)
                {
                    ButDel();
                    gCON.Enabled = false;
                }
                else
                {
                    ButCan();
                    gCON.Enabled = true;
                }
            }
            if (_cat == false && _img)
            {
                InputWhitimg();
                var que =
                    PopupNotification.PopUpMessageQuestion(
                        "Are you sure you want to Delete Image Name: " + txtNGM.Text.Trim(' ') + " " + "?", "Image Details");
                if (que)
                {
                    ButDel();
                    gIMG.Enabled = false;
                }
                else
                {
                    ButCan();
                    gIMG.Enabled = true;
                }
            }

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

        private void pbLogout_Click(object sender, EventArgs e)
        {
            PopupNotification.PopUpMassageLogOff();
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

        private void InputWhit()
        {
            txtCID.BackColor = Color.White;
            txtCOD.BackColor = Color.White;
            txtDET.BackColor = Color.White;
            cmbIMG.BackColor = Color.White;
            dkpREG.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtCID.Enabled = false;
            txtCOD.Enabled = true;
            txtDET.Enabled = true;
            cmbIMG.Enabled = true;
            dkpREG.Enabled = true;
        }
        private void InputDisb()
        {
            txtCID.Enabled = false;
            txtCOD.Enabled = false;
            txtDET.Enabled = false;
            cmbIMG.Enabled = false;
            dkpREG.Enabled = false;
        }
        private void InputClea()
        {
            txtCID.Clear();
            if (!_add == false)
            {
                txtCOD.Clear();
            }
           
            txtDET.Clear();
            cmbIMG.Text = "";

        }
        private void InputDimG()
        {
            txtCID.BackColor = Color.DimGray;
            txtCOD.BackColor = Color.DimGray;
            txtDET.BackColor = Color.DimGray;
            cmbIMG.BackColor = Color.DimGray;
            dkpREG.BackColor = Color.DimGray;
        }

        private void InputWhitimg()
        {
            txtIID.BackColor = Color.White;
            txtCGD.BackColor = Color.White;
            txtNGM.BackColor = Color.White;
            txtLGC.BackColor = Color.White;
            bntLOD.BackColor = Color.White;
        }
        private void InputEnabimg() {
            txtCGD.Enabled = true;
            txtNGM.Enabled = true;
            txtLGC.Enabled = false;
            bntLOD.Enabled = true;
        }
        private void InputDisbimg()
        {
            txtCGD.Enabled = false;
            txtNGM.Enabled = false;
            txtLGC.Enabled = false;
            bntLOD.Enabled = false;
        }
        private void InputCleaimg()
        {
            txtIID.Clear();
            if (_add == false)
            {
                txtCGD.Clear();
            }
            txtNGM.Clear();
            txtLGC.Clear();
          
        }
        private void InputDimGimg()
        {
            txtIID.BackColor = Color.DimGray;
            txtCGD.BackColor = Color.DimGray;
            txtNGM.BackColor = Color.DimGray;
            txtLGC.BackColor = Color.DimGray;
            bntLOD.BackColor = Color.DimGray;
        }


        private string GetLastImgId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<ProductImages>(unitWork);
                var result = (from b in repository.SelectAll(Query.AllProductImage)
                              orderby b.image_id descending
                              select b.image_code).Take(1).SingleOrDefault();
                if (result != null)
                {
                    return result;
                }
                result = Query.DefaultCode;
                return result;
            }
        }
        private string GetLastId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<Category>(unitWork);
                var result = (from b in repository.SelectAll(Query.AllCategory)
                              orderby b.category_id descending
                              select b.category_code).Take(1).SingleOrDefault();
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
            var alphaNumeric = new GenerateAlpaNum(3, 2, lastId, "CA");
            alphaNumeric.Increment();
            txtCOD.Text = alphaNumeric.ToString();
        }
        private void GenerateImgCode()
        {
            var lastCode = GetLastImgId();
            var lastId = GetSettings.GetLastBarcode(lastCode);
            var alphaNumeric = new GenerateAlpaNum(3, 2, lastId, "IP");
            alphaNumeric.Increment();
            txtCGD.Text = alphaNumeric.ToString();
        }


        private void ButAdd()
        {
            ButtonAdd();
            BntEnabled();
            _add = true;
            _edt = false;
            _del = false;
            gCON.Enabled = false;
            if (_cat && _img == false)
            {
               
                BindImage();
                InputEnab();
                InputWhit();
                InputClea();
                txtDET.Focus();
                GenerateCode();
            }
            if (_cat == false && _img)
            {
                GenerateImgCode();
                InputEnabimg();
                InputWhitimg();
                InputCleaimg();
                txtNGM.Focus();
            }

        }
        private void ButUpd()
        {
            ButtonUpd();
            _add = false;
            _edt = true;
            _del = false;
            if (_cat && _img == false)
            {
                InputEnab();
                InputWhit();
                gCON.Enabled = false;
            }
            if (_cat == false && _img)
            {
                InputEnabimg();
                InputWhitimg();
                gIMG.Enabled = false;
            }
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
            InputEnabimg();
            InputWhitimg();
            InputCleaimg();
            gCON.Enabled = true;
            cmbIMG.DataBindings.Clear();
        }
        private void ButSav()
        {
            if (_cat && _img == false)
            {
                SavCat();
            }
            if (_cat == false && _img)
            {
                SavImg();
            }      
        }
        private void ButCan()
        {
            ButtonCan();
            InputDisb();
            InputDimG();
            InputClea();
            gCON.Enabled = true;
            cmbIMG.DataBindings.Clear();
        }

        #region SaveCategory

        private void SavCat()
        {
            if (_add && _edt == false && _del == false && _img == false)
            {
                DataInsert();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindCategoryList();
            }
            if (_add == false && _edt && _del == false && _img == false)
            {
                DataUpdate();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindCategoryList();
            }
            if (_add == false && _edt == false && _del && _img == false)
            {
                DataDelete();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindCategoryList();
            }
            _add = false;
            _edt = false;
            _del = false;
            _cat = true;
            _img = false;
            gCON.Enabled = true;
            cmbIMG.DataBindings.Clear();
        }
#endregion

#region SaveImages

        private void SavImg()
        {
            if (_add && _img && _edt == false && _del == false && _cat == false)
            {
                DataImgInsert();
                ButtonSav();
                InputDisbimg();
                InputDimGimg();
                InputCleaimg();
                BindImageList();
            }
            if (_add == false && _edt && _img && _del == false && _cat == false)
            {
                DataImgUpdate();
                ButtonSav();
                InputDisbimg();
                InputDimG();
                InputCleaimg();
                BindImageList();
            }
            if (_add == false && _edt == false && _del && _img && _cat == false)
            {
                DataImgDelete();
                ButtonSav();
                InputDisbimg();
                InputDimGimg();
                InputCleaimg();
                BindImageList();
            }
            _add = false;
            _edt = false;
            _del = false;
            _img = true;
            _cat = false;
            gIMG.Enabled = true;
        }
#endregion


        

        private void BindCategoryList()
        {
            gCON.Update();
            try
            {
                gCON.DataBindings.Clear();
                gCON.DataSource = RebindCategory();
            }
            catch (Exception ex)
            {
                gCON.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableCategory);
            }
        }
        private void BindImageList()
        {
            gIMG.Update();
            try
            {
                gIMG.DataBindings.Clear();
                gIMG.DataSource = RebindImages();
            }
            catch (Exception ex)
            {
                gIMG.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableProductImage);
            }
        }
        private IEnumerable<ViewCategoryImage> RebindCategory()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewCategoryImage>(unWork);
                    return repository.SelectAll(Query.AllCategoryImage).ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleCategory);
                    throw;
                }
            }
        }
        private IEnumerable<ProductImages> RebindImages()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ProductImages>(unWork);
                    return repository.SelectAll(Query.AllProductImage).ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleProductImage);
                    throw;
                }
            }
        }

        //BINDING 
        private void BindImage()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<ProductImages>(unWork);
                var query = repository.SelectAll(Query.AllProductImage).Select(x => x.title).Distinct().ToList();
                cmbIMG.DataBindings.Clear();
                cmbIMG.DataSource = query;
            }
        }
        private int ProductImageId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ProductImages>(unWork);
                    var query = repository.FindBy(x => x.title == input);
                    return query.image_id;

                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Product Image Id Error", "Image Details");
                    throw;
                }
            }
        }


        #region ImgBrowse
        private void BrwImage()
        {
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
            imgOFD.Title = @"Open Image";
            imgOFD.Filter = Messages.ImageFormat;
            imgOFD.DefaultExt = "*.jpg";
            imgOFD.FilterIndex = 1;
            imgOFD.FileName = "";
            var result = imgOFD.ShowDialog();
            if (result == DialogResult.OK)
           {
                var imgFile = imgOFD.FileName;
                txtLGC.Text = imgFile;
                var objImg  = Image.FromFile(@imgFile);
                var imgType = Path.GetExtension(imgFile);
                _imgWidth   = objImg.Width;
                _imgHeight  = objImg.Height;
                _location   = imgFile;
                _code       = txtCGD.Text.Trim(' ');
                _title      = txtNGM.Text.Trim(' ');
                _type       = imgType.Trim(' ');
                objImg.Dispose();
            }
        }
        #endregion

#region ImgCRUD
        private void DataImgInsert()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ProductImages>(unWork);
                    var fileStream = new FileStream(_location, FileMode.Open);
                    var binaryReader = new BinaryReader(fileStream);
                    var image = binaryReader.ReadBytes((int) fileStream.Length);
                    var img = new ProductImages()
                    {
                        image_code    = _code,
                        image = image, 
                        title        = _title, 
                        img_type      = _type, 
                        img_location  = _location, 
                        img_height    = _imgHeight, 
                        img_width     = _imgWidth
                    };
                    var result = repository.Add(img);
                    if (result > 0)
                    {
                        PopupNotification.PopUpMessages(1, "Image Name: " + txtNGM.Text.Trim(' ') + " " + Messages.SuccessInsert,
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

      

        private void DataImgUpdate()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var imgId = Convert.ToInt32(txtIID.Text);
                    var repository = new Repository<ProductImages>(unWork);
                    var fileStream = new FileStream(_location, FileMode.Open);
                    var binaryReader = new BinaryReader(fileStream);
                    var image = binaryReader.ReadBytes((int)fileStream.Length);
                    var que = repository.Id(imgId);
                        que.image_code = _code;
                        que.image = image;
                        que.title = _title;
                        que.img_type = _type;
                        que.img_location = _location;
                        que.img_height = _imgHeight;
                        que.img_width = _imgWidth;
                    
                    var result = repository.Update(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, "Image Name: " + txtNGM.Text.Trim(' ') + " " + Messages.SuccessUpdate,
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
        private void DataImgDelete()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var imgId = Convert.ToInt32(txtIID.Text);
                    var repository = new Repository<ProductImages>(unWork);
                    var que = repository.Id(imgId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, "Image Name: " + txtNGM.Text.Trim(' ') + " " + Messages.SuccessDelete,
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
#endregion

#region DataCrud

        private void DataInsert()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk; 
                unWork.Begin();
                try
                {
                    var imgName = cmbIMG.Text.Trim(' ');
                    var repository = new Repository<Category>(unWork);
                    var category = new Category()
                    {
                        category_code    = txtCOD.Text.Trim(' '),
                        category_details = txtDET.Text.Trim(' '), 
                        image_id         = ProductImageId(imgName),
                        date_register    = dkpREG.Value.Date
                    };
                    var result = repository.Add(category);
                    if (result > 0)
                    {
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Category Code: " +
                                                           txtCOD.Text.Trim(' ')
                                                           + " " + Messages.SuccessInsert,
                            Messages.TitleSuccessInsert);
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
                    var catId = Convert.ToInt32(txtCID.Text);
                    var imgName = cmbIMG.Text.Trim(' ');
                    var repository = new Repository<Category>(unWork);
                    var que = repository.Id(catId);

                    que.category_code = txtCOD.Text.Trim(' ');
                    que.category_details = txtDET.Text.Trim(' ');
                    que.image_id = ProductImageId(imgName);
                    que.date_register = dkpREG.Value.Date;
                    var result = repository.Update(que);
                    if (result)
                    {
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Category Code: " +
                                                           txtCOD.Text.Trim(' ')
                                                           + " " + Messages.SuccessUpdate,
                            Messages.TitleSuccessUpdate);
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
                    var catId = Convert.ToInt32(txtCID.Text);
                    var repository = new Repository<Category>(unWork);
                    var que = repository.Id(catId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Category Code: " +
                                                           txtCOD.Text.Trim(' ')
                                                           + " " + Messages.SuccessDelete,
                            Messages.TitleSuccessDelete);
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedDelete);
                }
            }
        }
#endregion

        #region ImageButton

        private void BntEnabled()
        {
            bntLOD.Enabled = true;
        }
        #endregion


        private void DisplayImage(int imgId)
        {
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

        private void DisplayCategory(int imgId)
        {
            var img = GetByImage(imgId);
            if (img != null)
            {
                MemoryStream memoryStream = new MemoryStream(img);
                imgCAT.Image = Image.FromStream(memoryStream);
            }
            else
            {
                imgCAT.Image = null;
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

      

        private void bntUpload_Click(object sender, EventArgs e)
        {
            BrwImage();
        }
        private void tabCategory_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabCategory.SelectedTabPage == xCategory)
            {
                _cat = true;
                _img = false;
                gCON.Enabled = true;
                gIMG.Enabled = false;
            }
            if (tabCategory.SelectedTabPage == xImage)
            {
                _img = true;
                _cat = false;
                gCON.Enabled = false;
                gIMG.Enabled = true;
            }
        }

       

        private void gridImage_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridImage.RowCount > 0)
            {
                txtIID.Text = ((GridView)sender).GetFocusedRowCellValue("ImageId").ToString();
                txtCGD.Text = ((GridView)sender).GetFocusedRowCellValue("ImageCode").ToString();
                txtNGM.Text = ((GridView)sender).GetFocusedRowCellValue("Title").ToString();
                txtLGC.Text = ((GridView)sender).GetFocusedRowCellValue("ImgLocation").ToString();
                DisplayImage(Convert.ToInt32(txtIID.Text));
            }
        }

        private void gridImage_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhitimg();
        }

        private void dkpREG_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(dkpREG, bntSAV, "Image Register", Messages.TitleCategory);
        }

        private void dkpREG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(dkpREG, bntSAV, "Image Register", Messages.TitleCategory);
            }
        }

        

        private void gridImage_LostFocus(object sender, EventArgs e)
        {
            InputDimGimg();
        }

      

        private void gridCategory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridCategory.RowCount > 0)
            {
                try
                {
                    txtCID.Text = ((GridView)sender).GetFocusedRowCellValue("CategoryId").ToString();
                    txtCOD.Text = ((GridView)sender).GetFocusedRowCellValue("CategoryCode").ToString();
                    txtDET.Text = ((GridView)sender).GetFocusedRowCellValue("CategoryDetails").ToString();
                    cmbIMG.Text = ((GridView)sender).GetFocusedRowCellValue("Title").ToString();
                    dkpREG.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("DateRegister");
                    var imgId = ProductImageId(cmbIMG.Text);
                    DisplayCategory(imgId);
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
        }

        private void gridCategory_LostFocus(object sender, EventArgs e)
        {
            InputDimG();
        }

       

        //CATEGORY LEAVE
        private void txtDET_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtDET, cmbIMG, "Category Details", Messages.TitleCategory);
        }

        private void txtDET_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtDET, cmbIMG, "Category Details", Messages.TitleCategory);
            }
        }

        private void cmbIMG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIMG.Text.Length > 0)
            {
                var imgId = ProductImageId(cmbIMG.Text);
                DisplayCategory(imgId);
            }
        }

        private void cmbIMG_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(cmbIMG, dkpREG, "Image Title", Messages.TitleCategory);
        }

        private void cmbIMG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                BindImage();
            }
            if (e.KeyCode == Keys.Enter)
            {

                InputManipulation.InputBoxLeave(cmbIMG, dkpREG, "Image Title", Messages.TitleCategory);
            }
        }

        private void txtNGM_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtNGM, txtLGC, "Image Name", Messages.TitleProductImage);
        }

        private void txtNGM_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtNGM, txtLGC, "Image Name", Messages.TitleProductImage);
            }
        }
        private void txtLGC_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(txtLGC, bntLOD, "Image Location", Messages.TitleProductImage);
        }
        private void txtLGC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtLGC, bntLOD, "Image Location", Messages.TitleProductImage);
            }
        }
        private void bntLOD_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(bntLOD, bntSAV, "Image Upload", Messages.TitleProductImage);
        }
        private void bntLOD_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(bntLOD, bntSAV, "Image Upload", Messages.TitleProductImage);
            }
        }

    }
}
