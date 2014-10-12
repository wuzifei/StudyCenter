/* 
	calendar-cs-win.js
	language: Czech
	encoding: windows-1250
	author: Lubos Jerabek (xnet@seznam.cz)
	        Jan Uhlir (espinosa@centrum.cz)
*/

// ** I18N
Calendar._DN  = new Array('Neděle','Pondělí','Úterý','Středa','Čtvrtek','Pátek','Sobota','Neděle');
Calendar._SDN = new Array('Ne','Po','Út','St','Čt','Pá','So','Ne');
Calendar._MN  = new Array('Leden','Únor','Březen','Duben','Květen','Červen','Červenec','Srpen','Září','Říjen','Listopad','Prosinec');
Calendar._SMN = new Array('Led','Úno','Bře','Dub','Kvě','Črv','Čvc','Srp','Zář','Říj','Lis','Pro');

// tooltips
Calendar._TT = {};
Calendar._TT["INFO"] = "O komponentě kalendář";
Calendar._TT["TOGGLE"] = "Změna prvního dne v týdnu";
Calendar._TT["PREV_YEAR"] = "Předchozí rok (přidrž pro menu)";
Calendar._TT["PREV_MONT