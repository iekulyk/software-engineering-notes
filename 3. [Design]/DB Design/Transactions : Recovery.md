Transactions : Recovery
---

####Transactions should be durable, but we cannot prevent all sorts of failures:
  -  - System crashes
  -  - Power failures
  -  - Disk crashes
  -  - User mistakes
  -  - Sabotage
  -  - Natural disasters
  
  
Prevention is better 
than cure
  - -  Reliable OS
  - - Security
  - - UPS and surge protectors
  - - RAID arrays
  - - Can’t protect against everything though


###The Transaction Log

  - The transaction log records the details of all transactions
  - Any changes the transaction makes to the database
  - How to undo these changes
  - When transactions complete and how
