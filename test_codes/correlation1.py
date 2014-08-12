import urllib2
import csv
import sys
import string
from dateutil import parser as date_parser
from datetime import timedelta
from datetime import date
from datetime import datetime
import numpy as np
import time

class Data():

    def __init__(self, stock, time_period):
	#Today's date:
	today = date.today()
	#Load End of Day Quote from Google, then store in a temporary file

	if time_period == '1 day':
		eod_quote = urllib2.urlopen("https://www.google.com/finance/getprices?i=%i&p=%id&f=d,o,h,l,c,v&df=cpct&q=%s" %
			(60, 1, string.upper(stock)))
	if time_period == '2 days':
		eod_quote = urllib2.urlopen("https://www.google.com/finance/getprices?i=%i&p=%id&f=d,o,h,l,c,v&df=cpct&q=%s" %
			(120, 2, string.upper(stock)))
	if time_period == '1 week':
		eod_quote = urllib2.urlopen("https://www.google.com/finance/getprices?i=%i&p=%id&f=d,o,h,l,c,v&df=cpct&q=%s" %
			(360, 5, string.upper(stock)))
	if time_period == '1 month':
		eod_quote = urllib2.urlopen("https://www.google.com/finance/getprices?i=%i&p=%id&f=d,o,h,l,c,v&df=cpct&q=%s" %
			(3600, 30, string.upper(stock)))
	if time_period == '1 year':
		eod_quote = urllib2.urlopen("http://ichart.finance.yahoo.com/table.csv?s=%s&a=%i&b=%i&c=%i&d=%i&e=%i&f=%i&g=d&ignore=.csv" %
			(string.upper(stock),today.month, today.day, today.year-1, today.month, today.day, today.year ))
	if time_period == '5 years':
		eod_quote = urllib2.urlopen("http://ichart.finance.yahoo.com/table.csv?s=%s&a=%i&b=%i&c=%i&d=%i&e=%i&f=%i&g=d&ignore=.csv" %
			(string.upper(stock),today.month, today.day, today.year-5, today.month, today.day, today.year ))
		

	time.sleep(1)
	output = open('./eod_quotes/'+stock+'.dat', 'w')
	output.write(eod_quote.read())
	output.close()

	#Parse the temporary file
	self.date_stamp = []
	self.open_val = []
	self.close_val = []
	self.low_val = []
	self.high_val = []
	self.volume_val = []

	self.date = []


	#If using googles API:
	if time_period in ['1 day', '2 days', '1 week', '1 month']:
		with open('./eod_quotes/'+stock+'.dat', 'r') as csvfile:
			eod_reader = csv.reader(csvfile, delimiter = ',')
			row_num = 0
			for row in eod_reader:

				#Some shitty programming to get intervals and timestamps from the google data header
				if row_num < 8:
					if row_num == 3:
						self.interval = row[0]
						self.interval = int(self.interval[9:])
					if row_num == 7:
						self.benchmark = int(row[0][1:]) + 10800	#time difference btw east and west coasts
				else:
					self.date_stamp.append(row[0])
					self.open_val.append(row[4])
					self.high_val.append(row[2])
					self.low_val.append(row[3])
					self.close_val.append(row[1])
					self.volume_val.append(row[5])
				row_num = row_num +1

		#Dealing with google's ridiculous way of writing datestamps
		for i in range(len(self.date_stamp)):
			if self.date_stamp[i][0] =='a':
				self.benchmark = int(self.date_stamp[i][1:]) + 10800
				self.date_stamp[i] = int(self.date_stamp[i][1:]) + 10800
			else:
				self.date_stamp[i] = int(self.date_stamp[i])*self.interval+self.benchmark
		#Format date strings to something matplotlib can work with
		for item in self.date_stamp:
			self.date.append(datetime.fromtimestamp(item))

	#If using Yahoo's API:
	elif time_period in ['1 year', '5 years']:
		row_num = 0
		with open('./eod_quotes/'+stock+'.dat', 'r') as csvfile:
			eod_reader = csv.reader(csvfile, delimiter = ',')
			for row in eod_reader:
				if row_num == 0:
					pass
				else:
					self.date_stamp.append(row[0])
					self.open_val.append(row[1])
					self.high_val.append(row[2])
					self.low_val.append(row[3])
					self.close_val.append(row[4])
					self.volume_val.append(row[5])
				row_num = row_num + 1

		#Reverse all lists
		self.date_stamp = self.date_stamp[::-1]
		self.open_val = self.open_val[::-1]
		self.high_val = self.high_val[::-1]
		self.low_val = self.low_val[::-1]
		self.close_val = self.close_val[::-1]
		self.volume_val = self.volume_val[::-1]
		#Parse datestamps into datetime objects
		for item in self.date_stamp:
			self.date.append(date_parser.parse(item))


	for i in range(len(self.open_val)):
		self.open_val[i] = float(self.open_val[i])
		self.close_val[i] = float(self.close_val[i])
		self.high_val[i] = float(self.high_val[i])
		self.low_val[i] = float(self.low_val[i])
		self.volume_val[i] = float(self.volume_val[i])


	#Make numpy arrays of the data, in case you want to do any calculations with it
	self.open_val_array = np.array(self.open_val)
	self.close_val_array = np.array(self.close_val)
	self.high_val_array = np.array(self.high_val)
	self.low_val_array = np.array(self.low_val)
	self.volume_val_array = np.array(self.volume_val)

for sym in ['csco', 'ziop', 'aapl', 'msft', 'gnmk', 'ecty', 'goog', 'abb', 'ace', 'acc']:
	run1 = Data(sym, '1 year')
	C1 = []
	N=0
	corr=0
	for j in range(len(run1.volume_val)-1):
		for i in range(len(run1.volume_val)-j):
			N = N+run1.close_val[i+j]*run1.volume_val[i+j]
			corr = corr + run1.close_val[i+j]*run1.volume_val[i]
		C1.append(1/N*corr)
	print sym + ': ' + str(min(C1))+ ' ' + str(max(C1))
	print 'change: ' + str(100*(run1.close_val[len(run1.close_val)-1]-run1.open_val[0])/run1.open_val[0])





