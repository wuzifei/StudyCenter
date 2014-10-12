/* The main calendar widget.  DIV containing a table. */

.calendar {
  position: relative;
  display: none;
  border-top: 2px solid #fff;
  border-right: 2px solid #000;
  border-bottom: 2px solid #000;
  border-left: 2px solid #fff;
  font-size: 11px;
  color: #000;
  cursor: default;
  background: #d4d0c8;
  font-family: tahoma,verdana,sans-serif;
}

.calendar table {
  border-top: 1px solid #000;
  border-right: 1px solid #fff;
  border-bottom: 1px solid #fff;
  border-left: 1px solid #000;
  font-size: 11px;
  color: #000;
  cursor: default;
  background: #d4d0c8;
  font-family: tahoma,verdana,sans-serif;
}

/* Header part -- contains navigation buttons and day names. */

.calendar .button { /* "<<", "<", ">", ">>" buttons have this class */
  text-align: center;
  padding: 1px;
  border-top: 1px solid #fff;
  border-right: 1px solid #000;
  border-bottom: 1px solid #000;
  border-left: 1px solid #fff;
}

.calendar .nav {
  background: transparent url(menuarrow.gif) no-repeat 100% 100%;
}

.calendar thead .title { /* This holds the current "month, year" */
  font-weight: bold;
  padding: 1px;
  border: 1px solid #000;
  background: #848078;
  color: #fff;
  text-align: center;
}

.calendar thead .headrow { /* Row <TR> containing navigation buttons */
}

.calendar thead .daynames { /* Row <TR> containing the day names */
}

.calendar thead .name { /* Cells <TD> containing the day names */
  border-bottom: 1px solid #000;
  padding: 2px;
  text-align: center;
  background: #f4f0e8;
}

.calendar thead .weekend { /* How a weekend day name shows in header */
  color: #f00;
}

.calendar thead .hilite { /* How do the buttons in header appear when hover */
  border-top: 2px solid #fff;
  border-right: 2px solid #000;
  border-bottom: 2px solid #000;
  border-left: 2px solid #fff;
  padding: 0px;
  background-color: #e4e0d8;
}

.calendar thead .active { /* Active (pressed) buttons in header */
  padding: 2px 0px 0px 2px;
  border-top: 1px solid #000;
  border-right: 1px solid #fff;
  border-bottom: 1px solid #fff;
  border-left: 1px solid #000;
  background-color: #c4c0b8;
}

/* The body part -- contains all the days in month. */

.calendar tbody .day { /* Cells <TD> containing month days dates */
  width: 2em;
  text-align: right;
  padding: 2px 4px 2px 2px;
}
.calendar tbody .day.othermonth {
  font-size: 80%;
  color: #aaa;
}
.calendar tbody .day.othermonth.oweekend {
  color: #faa;
}

.calendar table .wn {
  padding: 2px 3px 2px 2px;
  border-right: 1px solid #000;
  background: #f4f0e8;
}

.calendar tbody .rowhilite td {
  background: #e4e0d8;
}

.calendar tbody .rowhilite td.wn {
  background: #d4d0c8;
}

.calendar tbody td.hilite { /* Hovered cells <TD> */
  padding: 1px 3px 1px 1px;
  border-top: 1px solid #fff;
  border-right: 1px solid #000;
  border-bottom: 1px solid #000;
  border-left: 1px solid #fff;
}

.calendar tbody td.active { /* Active (pressed) cells <TD> */
  padding: 2px 2px 0px 2px;
  b