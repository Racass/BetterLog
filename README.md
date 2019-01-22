# BetterLog
A pretty fast logger

It uses in-memory saving to have a faster saving.
The BetterLog will save the message in a queue and save it on the respective type (MSSQL, file TXT/CSV) after a configurable time span, using a new thread. 


# TODO

 * logs types
   * ~Implements TXT~
   * Implements CSV
   * Implements MSSQL
   * Implements MySQL
   * Implements Hana 
   * Implements SAP Business One UDT
 * Visualization
   * Implements a SAP Business One form to see the log    
   * Implements a windows forms screen to visualize the log
 * Others
   * Create a documentation
   * Levels of debug
    * Based on the debug level, will save the message or not.
