EmployeeDirectory
=================

Sample Xamarin app connecting to IBM MobileFirst Platform.

This demo shows a very simplistic Xamarin iOS application connecting to an IBM MobileFirst adapter.  

Creating the MobileFirst service (Requires MobileFirst Platform CLI Tools from IBM)

From the command line:

- mfp create EmployeeDirectory
- cd EmployeeDirectory
- mfp add api EmployeeDirectoryiOS -e ios
- mfp add adapter EmployeeAdapter --type http

Now replace both the EmployeeAdapter-impl.js and the EmployeeAdapter.xml files (these will be in the adapters subdirectory) with the same two files in MobileFirstFiles directory inside this repository.

From project root directory:

- mfp start
- mfp push

Test service:

- mfp invoke

Type "Wen%20Li" when prompted.  Address results should appear.

In Xamarin iOS project...edit worklight.plist and replace IP address with your server's IP address (most likely your local machine).  Build and run on simulator.  Running on device may require additional network setup in order for you device to access your development machine's worklight server.

Note: In order to keep this sample as bare-bones as possible, a lot of "nice to haves" are not in this demo.  For example, the search expects exact matching and is case sensitive.
