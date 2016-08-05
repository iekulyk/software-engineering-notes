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

  - The log is stored on disk, not in memory
  - If the system crashes it is preserved
  - Write ahead log rule
  - The entry in the log must be made before COMMIT processing can complete
  
###System Failures

  - A system failure means all running transactions are affected
  - Software crashes
  - Power failures
  - The physical media (disks) are not damaged
   
  - At various times a DBMS takes a checkpoint
  - All committed transactions are written to disk
  - A record is made (on disk) of the transactions that are currently running
  
###System Recovery

  - Any transaction that was running at the time of failure needs to be undone and restarted
  - Any transactions that committed since the last checkpoint need to be redone 

###Transaction Recovery

UNDO and REDO: lists of transactions

UNDO = all transactions running at the last checkpoint
REDO = empty

For each entry in the log, starting at the last checkpoint
  If a BEGIN TRANSACTION entry is found for T
    Add T to UNDO
  If a COMMIT entry is found for T
    Move T from UNDO to REDO


###Forwards and Backwards

####Backwards recovery

  - We need to undo some transactions
  - Working backwards through the log we undo any operation by a transaction on the UNDO list
  - This returns the database to a consistent state

####Forwards recovery

  - Some transactions need to be redone
  - Working forwards through the log we redo any operation by a transaction on the REDO list
  - This brings the atabase up to date
  
###Media Failures

####System failures are not too severe

  - only information since the last checkpoint is affected
  - this can be recovered from the transaction log

####Media failures (disk crashes etc.) are more serious
  
  - The data stored to disk is damaged
  - The transaction log itself may be damaged
  
###Backups

  - Backups are needed to recover from media failure
  - The transaction log and entire contents of database is written to secondaty storage (often tape)
  - Time consuming and often requires down time
  
#### Backups frequency

  - Frequent enaught that little information is lost
  - Not so frequent as to cause problems
  - Every day (night) is common
  
###Recovery from Media Failure

  - Restore the database from last backup
  - Use the transaction log to redo any changes made since the last backup
  - if Step 2 is possible (log is damaged)
    - Store the log on a separate physical device to the database
    - the risk of losing both is then reduced
    
