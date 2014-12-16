EmployeeDirectory
=================

Sample Xamarin app connecting to IBM MobileFirst Platform.

This demo shows a very simplistic Xamarin iOS application connecting to an IBM MobileFirst adapter.  

Creating the MobileFirst service (Requires Worklight CLI Tools from IBM)

From the command line:

- wl create EmployeeDirectory
- cd EmployeeDirectory
- wl add api EmployeeDirectoryiOS -e ios
- wl add adapter EmployeeAdapter --type http

Now replace both the EmployeeAdapter-impl.js and the EmployeeAdapter.xml files with the same two files in this repository.

From project root directory:

- wl start
- wl build
- wl deploy

Test service:

- wl invoke
Type "Wen%20Li" when prompted.  Address results should appear.

In Xamarin iOS project...edit worklight.plist and replace IP address with your server's IP address (most likely your local machine).  Build and run on simulator.  Running on device may require additional network setup in order for you device to access your development machine's worklight server.


