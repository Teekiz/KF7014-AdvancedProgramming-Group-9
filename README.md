# KF7014-AdvancedProgramming-Group-9
KF7014 - Advanced Programming - Group 9s IronHelm Project

OPTIMAL SETUP
================
- Set App.config files to your local directory. Comment out other directories.
- Delete database and create again within the DataAccessLayer (database built into VS2019). Rename Database to Database.mfd
- In Solution properties, set startup project to "Presenter"

KNOWN BUGS
================
- Schedule after debugger is stopped and ran again can be intermittent. Works 90% of the time but is known not to update after debugger restart.
- On Manager form, Attempting to update schedule end date after order completion will sometimes return message box "There is an order during that time period"
- Code has naming rule violations. This could not be sorted due to time constraints. This does not affect functionality

TESTING NOTE
================
- Due to time constaints, testing for the presentation layer was done manually. This can be found in the test document. These tests did not utilise testing functionality built into VS2019.
