## Supercell.Magic - Project
***Supercell.Magic*** is a Clash of Clans Server.
The goal of this server was to implement all the features of Clash of Clans and support millions of players.
Supercell.Magic uses dedicated threads and async operators. 
**Couchbase servers** & a **memory based** saving server will be used to save players.

I, [Salty Coder](https://github.com/Salty-Coder) have fixed many issues in this project and left it in a state which is easy to set up.   
This server now runs fine. However, clients still cannot connect for some reason. If you manage to fix it, please contribute to this repository.   

### Info to note
The assets folder contains decrypted .csv files as the SevenZip decryption within Supercell.Magic no longer works.   
`Supercell.Magic.Servers.Account`, `Supercell.Magic.Servers.Alliance`, and `Supercell.Magic.Servers.Admin` still do not work and have been omitted from start.bat.


This is **complex to set up** but 1000x less complex than the original project.

## How to run

1. Set up a couchbase server (look up a tutorial).   
2. Create 5 couchbase buckets, `magic-players`, `magic-admin`, `magic-alliances`, `magic-streams`, `magic-seasons`.   
3. Change couchbase configuration ip:
   - If you are hosting locally:   
      - keep line 68 of [evironment.json](https://github.com/Salty-Coder/Supercell.Magic-my-turn/blob/master/www/environment.json) as `127.0.0.1`.   
   - If you are hosting on a remote server:
      - change line 68 of [evironment.json](https://github.com/Salty-Coder/Supercell.Magic-my-turn/blob/master/www/environment.json) from `127.0.0.1` to the ip of your server.   
4. Enter your couchbase username and password on lines 70 and 71 of [evironment.json](https://github.com/Salty-Coder/Supercell.Magic-my-turn/blob/master/www/environment.json).
5. Set up a redis server (look up a tutorial).
6. Change redis connection string in [evironment.json](https://github.com/Salty-Coder/Supercell.Magic-my-turn/blob/master/www/environment.json):
   - If you are hosting locally:   
      - keep line 86 and 90 of [evironment.json](https://github.com/Salty-Coder/Supercell.Magic-my-turn/blob/master/www/environment.json) as `127.0.0.1:6379`.   
   - If you are hosting on a remote server:
      - change line 86 and 90 of [evironment.json](https://github.com/Salty-Coder/Supercell.Magic-my-turn/blob/master/www/environment.json) from `127.0.0.1:6379` to the ip or hostname of your server (remember to include `:6379`).   
7. If you set a password to your redis server (to increase security), add `,password=yourpassword` to the end of the connection string, incorporating your password (e.g. `1.2.3.4:6379,password=pass123`).   
8. Set up an http web server where /supercell is the contents of the [www](https://github.com/Salty-Coder/Supercell.Magic-my-turn/blob/master/www/) folder.   
9. Replace `127.0.0.1:8000` in [ResourceSettings.cs](https://github.com/Salty-Coder/Supercell.Magic-my-turn/blob/master/Supercell.Magic.Servers.Core/Settings/ResourceSettings.cs) to your http server IP and the port the web server is running on.   
10. Replace `127.0.0.1` in [ServerCore.cs](https://github.com/Salty-Coder/Supercell.Magic-my-turn/blob/master/Supercell.Magic.Servers.Core/Settings/ServerCore.cs) with your http server IP if running on a remote server, and, if necessary, and the port the web server is running on.   

Yes I know that is a lot of instructions but it is 10000000x easier than resolving all the issues from the original repository.
