# BetterLog
A pretty fast logger

It uses in-memory saving to have a faster saving.
The BetterLog will save the message in a queue and save it on the respective type (MSSQL, file TXT/CSV) after a configurable time span, using a new thread. 

* Important *
The class "Robo" used as startup, is just a console that will send the message to the BetterLog library.
