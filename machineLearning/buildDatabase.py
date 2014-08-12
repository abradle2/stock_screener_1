#!/usr/bin/python
# -*- coding: utf-8 -*-


import urllib2
import csv
import sys
import string
from dateutil import parser as date_parser
from datetime import timedelta
from datetime import date
from datetime import datetime
import numpy as np
from itertools import islice
import time
import os
import fnmatch

class Data():

    def __init__(self, stock, industry):
        #Today's date:
        today = date.today()
        try:
            eod_quote = urllib2.urlopen("http://ichart.finance.yahoo.com/table.csv?s=%s&a=%i&b=%i&c=%i&d=%i&e=%i&f=%i&g=d&ignore=.csv" %
                (string.upper(stock),today.month, today.day, today.year-1, today.month, today.day, today.year ))

            #Get Company Info
            '''
                book
                EPS
                EPS estimate current year
                EPS estimate next year
                EPS estimate next quarter
                52 week low
                52 week high
                Dividend/share
                Market Cap
                50 day moving average
                200 day moving average
                P/E ratio
                P/S ratio
                P/B ratio
                PEG ratio
                Price/EPS estimate next year
                Price/EPS estimate current year
                Short ratio
                1 yr target price
                EBITDA
                Volume
                Exchange
                Industry
                Symbol
                23 Items
        
                '''
            company_info = urllib2.urlopen("http://finance.yahoo.com/d/quotes.csv?s=%s&f=b4ee7e8e9jkdj1m3m4rp5p6r5r7r6s7t8j4vx" %
                (string.upper(stock)))

            #time.sleep(0.5)
            output = open('./eod_quotes/'+stock+'.dat', 'w')
            output.write(eod_quote.read())
            output.close()
            output_company_info = open('./company_info/'+stock+'.dat', 'w')
            output_company_info.write(company_info.read())
            output_company_info.close()
    
            #Parse the temporary file

            #If using Yahoo's API:
        
            with open('./eod_quotes/'+stock+'.dat', 'r') as csvfile:
                tempRows = []
                eod_reader = csv.reader(csvfile, delimiter = ',')
                
                for row in eod_reader:
                    tempRows.append(row)
                for j in range(len(tempRows)):
                    if j == 0:
                        pass
                    elif j > 100:
                        pass
                    else:
                        #gain = (today-yesterday)/yesterday
                        _gain = (float(tempRows[j][4])-float(tempRows[j+1][4]))/float(tempRows[j+1][4])
                        database.write("%.2f" %_gain)
                        #database.write(str(eod_reader[j][4]))
                        database.write(', ')
                    j +=1
    
            with open('./company_info/'+stock+'.dat', 'r') as csvfile:
                eod_reader = csv.reader(csvfile, delimiter = ',')
                for row in eod_reader:
                    for i in row:
                        database.write(str(i))
                        database.write(', ')
            database.write(industry + ', ' + stock)
            database.write('\r')
        except:
            print stock + ' Is Not Available'
    '''
    Final Structure of database file:
    100 percent gains, as calulated above [ie: (today-yesterday)/yesterday]. Ignores days when market is closed. 
    book
    EPS
    EPS estimate current year
    EPS estimate next year
    EPS estimate next quarter
    52 week low
    52 week high
    Dividend/share
    Market Cap
    50 day moving average
    200 day moving average
    P/E ratio
    P/S ratio
    P/B ratio
    PEG ratio
    Price/EPS estimate next year
    Price/EPS estimate current year
    Short ratio
    1 yr target price
    EBITDA
    Volume
    Exchange
    Industry
    Symbol
    23 Items
    
    '''


syms = []
industries = []
symbolFiles = []
for file in os.listdir("./companySymbols"):
    if fnmatch.fnmatch(file, '*.csv'):
        symbolFiles.append(file)

print symbolFiles

database = open('./companyDatabase.csv', 'w')

#Load symbols for all comapnies we have a listing for:
for f in symbolFiles:
    print "Now Loading Companies from %s" %f
    with open('./companySymbols/%s' %f, 'r') as _file:
        row_num = 0
        reader1 = csv.reader(_file, delimiter = ',')
        for row in reader1:
            if row_num ==0:
                pass
            else:
                syms.append(row[0])
                industries.append(row[7])
            row_num +=1


print "Now fetching information for %i companies" %len(syms)

for i in range(len(syms)):
    print syms[i]
    run = Data(syms[i], industries[i])

database.close()








