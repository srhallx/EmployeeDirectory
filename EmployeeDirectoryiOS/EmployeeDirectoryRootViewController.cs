using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;
using Worklight.Xamarin.iOS;
using EmployeeDirectory;
using System.Threading.Tasks;

namespace EmployeeDirectoryiOS
{
	partial class EmployeeDirectoryRootViewController : UIViewController
	{
		private EmployeeDirectoryClient employeeDirectory;

		public EmployeeDirectoryRootViewController (IntPtr handle) : base (handle)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			employeeDirectory = new EmployeeDirectoryClient (WorklightClient.CreateInstance ());

			RetrieveAllEmployees ();

			tbxSearch.ShouldReturn += (textField) => {
				tbxSearch.ResignFirstResponder ();
				return true;
			};

			tbxSearch.Ended += async delegate(object sender, EventArgs e) {
				Employee[] empRecord;

				if (tbxSearch.Text.Length > 0) 
					empRecord = await employeeDirectory.FindEmployee (tbxSearch.Text);
				else
					empRecord = await employeeDirectory.AllEmployees();

				tblEmployees.DataSource = new TableSource(empRecord);
				tblEmployees.ReloadData();
			};
		}
			
		private async Task<bool> RetrieveAllEmployees()
		{
			Employee[] employeeRecord = await employeeDirectory.AllEmployees();
			tblEmployees.DataSource = new TableSource(employeeRecord);
			tblEmployees.ReloadData();
			return true;
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "DetailSegue") { // set in Storyboard
				var navctlr = segue.DestinationViewController as EmployeeDirectoryDetailViewController;
				if (navctlr != null) {
					var source = tblEmployees.DataSource as TableSource;
					var rowPath = tblEmployees.IndexPathForSelectedRow;
					var item = source.GetItem(rowPath.Row);
					navctlr.SetEmployee (this, item); // to be defined on the TaskDetailViewController
				}
			}
		}
			
	}

	public class TableSource : UITableViewDataSource {
		Employee[] employeeRecords;
		string cellIdentifier = "TableCell";
		public TableSource (Employee[] items)
		{
			employeeRecords = items;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return employeeRecords.Length;
		}
			
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);

			cell.TextLabel.Text = employeeRecords[indexPath.Row].FullName;
			cell.DetailTextLabel.Text = employeeRecords [indexPath.Row].Title;

			return cell;
		}

		public Employee GetItem(int id) 
		{
			return employeeRecords [id];
		}
			
	}
}
