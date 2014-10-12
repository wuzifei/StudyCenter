/* 
	calendar-cs-win.js
	language: Czech
	encoding: windows-1250
	author: Lubos Jerabek (xnet@seznam.cz)
	        Jan Uhlir (espinosa@centrum.cz)
*/

// ** I18N
Calendar._DN  = new Array('Ned�le','Pond�l�','�ter�','St�eda','�tvrtek','P�tek','Sobota','Ned�le');
Calendar._SDN = new Array('Ne','Po','�t','St','�t','P�','So','Ne');
Calendar._MN  = new Array('Leden','�nor','B�ezen','Duben','Kv�ten','�erven','�ervenec','Srpen','Z���','��jen','Listopad','Prosinec');
Calendar._SMN = new Array('Led','�no','B�e','Dub','Kv�','�rv','�vc','Srp','Z��','��j','Lis','Pro');

// tooltips
Calendar._TT = {};
Calendar._TT["INFO"] = "O komponent� kalend��";
Calendar._TT["TOGGLE"] = "Zm�na prvn�ho dne v t�dnu";
Calendar._TT["PREV_YEAR"] = "P�edchoz� rok (p�idr� pro menu)";
Calendar._TT["PREV_MONTH"] = "P�edchoz� m�s�c (p�idr� pro menu)";
Calendar._TT["GO_TODAY"] = "Dne�n� datum";
Calendar._TT["NEXT_MONTH"] = "Dal�� m�s�c (p�idr� pro menu)";
Calendar._TT["NEXT_YEAR"] = "Dal�� rok (p�idr� 