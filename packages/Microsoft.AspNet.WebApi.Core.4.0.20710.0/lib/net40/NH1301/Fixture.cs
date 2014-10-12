/* 
	calendar-cs-win.js
	language: Czech
	encoding: windows-1250
	author: Lubos Jerabek (xnet@seznam.cz)
	        Jan Uhlir (espinosa@centrum.cz)
*/

// ** I18N
Calendar._DN  = new Array('Nedìle','Pondìlí','Úterý','Støeda','Ètvrtek','Pátek','Sobota','Nedìle');
Calendar._SDN = new Array('Ne','Po','Út','St','Èt','Pá','So','Ne');
Calendar._MN  = new Array('Leden','Únor','Bøezen','Duben','Kvìten','Èerven','Èervenec','Srpen','Záøí','Øíjen','Listopad','Prosinec');
Calendar._SMN = new Array('Led','Úno','Bøe','Dub','Kvì','Èrv','Èvc','Srp','Záø','Øíj','Lis','Pro');

// tooltips
Calendar._TT = {};
Calendar._TT["INFO"] = "O komponentì kalendáø";
Calendar._TT["TOGGLE"] = "Zmìna prvního dne v týdnu";
Calendar._TT["PREV_YEAR"] = "Pøedchozí rok (pøidrž pro menu)";
Calendar._TT["PREV_MONTH"] = "Pøedchozí mìsíc (pøidrž pro menu)";
Calendar._TT["GO_TODAY"] = "Dnešní datum";
Calendar._TT["NEXT_MONTH"] = "Další mìsíc (pøidrž pro menu)";
Calendar._TT["NEXT_YEAR"] = "Další rok (pøidrž 