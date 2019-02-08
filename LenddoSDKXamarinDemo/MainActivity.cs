using Android.App;
using Android.Widget;
using Android.OS;
using Com.Lenddo.Mobile.Core;
using Com.Lenddo.Mobile.Datasdk;
using Com.Lenddo.Mobile.Datasdk.Models;
using Com.Lenddo.Mobile.Onboardingsdk.Client;
using Com.Lenddo.Mobile.Onboardingsdk.Utils;
using Com.Lenddo.Mobile.Onboardingsdk.Models;
using Java.Lang;
using Android.Content;
using Android.Content.PM;

namespace LenddoSDKXamarinDemo
{
    [Activity(Label = "LenddoSDKXamarinDemo", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, ILenddoEventListener
    {
        EditText edt_application_id;
        EditText edt_partner_script_id;

        EditText edt_firstname;
        EditText edt_middlename;
        EditText edt_lastname;
        EditText edt_university;
        EditText edt_employer;
        EditText edt_email;
        EditText edt_work_email;
        TextView tv_success;


        Button btn_startonboarding;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Initialize LenddoCoreInfo
            Log.Instance.DisplayLog = true;
            LenddoCoreInfo.InitCoreInfo(ApplicationContext);
            //LenddoCoreInfo.SetDataPartnerScriptId(ApplicationContext, "5b45f5b2f7a57920b62e63e7");
            //LenddoCoreInfo.SetOnboardingPartnerScriptId(ApplicationContext, "5b45f5b2f7a57920b62e63e7");

            // Initialize Fields
            edt_application_id = FindViewById<EditText>(Resource.Id.edt_application_id);
            edt_partner_script_id = FindViewById<EditText>(Resource.Id.edt_partner_script_id);
            edt_firstname = FindViewById<EditText>(Resource.Id.edt_firstname);
            edt_middlename = FindViewById<EditText>(Resource.Id.edt_middlename);
            edt_lastname = FindViewById<EditText>(Resource.Id.edt_lastname);
            edt_university = FindViewById<EditText>(Resource.Id.edt_university);
            edt_employer = FindViewById<EditText>(Resource.Id.edt_employer);
            edt_email = FindViewById<EditText>(Resource.Id.edt_email);
            edt_work_email = FindViewById<EditText>(Resource.Id.edt_work_email);
            tv_success = FindViewById<TextView>(Resource.Id.tv_success);
            edt_application_id.Text = generateRandomApplicationId();


            // Get our button from the layout resource, and attach an event to it
            //Button btn_collect_mobile_data = FindViewById<Button>(Resource.Id.btn_collect_mobile_data);
            btn_startonboarding = FindViewById<Button>(Resource.Id.btn_startonboarding);

            //btn_collect_mobile_data.Click += delegate
            //{
            //    btn_collect_mobile_data.Text = "Collect Mobile Data";
            //    //startDataSDK();
            //    //startOnboardingSDK();
            //};

            btn_startonboarding.Click += delegate
            {
                startOnboardingSDK();
                btn_startonboarding.Enabled = false;
            };
        }

        void ILenddoEventListener.OnAuthorizeCanceled(FormDataCollector collector)
        {
            Log.W("LenddoSDK", "OnAuthorizeCanceled()");
            btn_startonboarding.Enabled = true;
        }

        void ILenddoEventListener.OnAuthorizeComplete(FormDataCollector collector)
        {
            Log.W("LenddoSDK", "OnAuthorizeComplete() appid: " + collector.ApplicationId);
            tv_success.Text = "Onboarding Completed Successfully\napplication_id: " + collector.ApplicationId;
        }

        void ILenddoEventListener.OnAuthorizeError(int status_code, string rawresponse)
        {
            Log.W("LenddoSDK", "OnAuthorizeError()");
            btn_startonboarding.Enabled = true;
            tv_success.Text = "Onboarding Error: " + rawresponse;
        }

        void ILenddoEventListener.OnAuthorizeFailure(Throwable p0)
        {
            Log.W("LenddoSDK", "OnAuthorizeFailure()");
            btn_startonboarding.Enabled = true;
            tv_success.Text = "Onboarding Failure: " + p0.Message;
        }

        void ILenddoEventListener.OnAuthorizeStarted(FormDataCollector p0)
        {
            Log.W("LenddoSDK", "OnAuthorizeStarted()");
        }

        bool ILenddoEventListener.OnButtonClicked(FormDataCollector formData)
        {
            formData.ApplicationId = edt_application_id.Text;
            formData.PartnerScriptId = edt_partner_script_id.Text;
            formData.FirstName = edt_firstname.Text;
            formData.MiddleName = edt_middlename.Text;
            formData.LastName = edt_lastname.Text;
            formData.UniversityName = edt_university.Text;
            formData.EmployerName = edt_employer.Text;
            formData.Email = edt_email.Text;
            formData.WorkEmail = edt_work_email.Text;
            return true;
        }

        private void startDataSDK()
        {
            ClientOptions clientOptions = new ClientOptions();
            clientOptions.EnableLogDisplay(true);
            AndroidData.Setup(ApplicationContext, clientOptions);
            AndroidData.StartAndroidData(this, edt_application_id.Text);
        }

        private string generateRandomApplicationId()
        {
            System.Random random = new System.Random();
            return "XAM_" + String.ValueOf(random.Next());
        }

        private void startOnboardingSDK()
        {
            UIHelper helper = new UIHelper(this, this);
            helper.Collector.ApplicationId = edt_application_id.Text;
            helper.Collector.PartnerScriptId = edt_partner_script_id.Text;
            helper.ShowAuthorize();
        }
    }
}

