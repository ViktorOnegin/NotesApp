using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace Notes
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainPageActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainPageLayout);

            var Viewbtn = FindViewById<Button>(Resource.Id.ViewBtn);
            var Addbtn = FindViewById<Button>(Resource.Id.AddBtn);

            Viewbtn.Click += ViewBTN_Click;
            Addbtn.Click += AddBTN_Click;

        }

        private void ViewBTN_Click(object sender, System.EventArgs e)
        {
            var ViewNotes = new Intent(this, typeof(ViewNotesActivity));
            StartActivity(ViewNotes);
        }

        private void AddBTN_Click(object sender, System.EventArgs e)
        {
            var AddNotes = new Intent(this, typeof(AddNotesActivity));
            StartActivity(AddNotes);
        }
    }
}