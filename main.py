#!/usr/bin/python
# -*- coding: utf-8 -*-


import numpy as np
import wxversion
wxversion.select('2.8')
import wx
import wx.lib.newevent
import matplotlib
matplotlib.use('WXagg')
from matplotlib.figure import Figure
from matplotlib.backends.backend_wxagg import FigureCanvasWxAgg as FigCanvas
import matplotlib.pyplot as plt
from matplotlib.backends.backend_wx import NavigationToolbar2Wx
import matplotlib.ticker as ticker
import time
from numeric import Data
import threading



class GraphFrame(wx.Frame):
    #The main frame of the application
    def __init__(self):
	#I am using the __init__ method to set up the GUI interface initially, then looping with Mainloop()
        wx.Frame.__init__(self, None, title='Historical Data Stock Analyzer', pos=(150,150))

        self.Bind(wx.EVT_CLOSE, self.on_exit)			
	self.Bind(wx.EVT_CHECKBOX, self.draw_graph)		#Redraw the graph whenever a checkbox is clicked

	self.menubar = wx.MenuBar()
	self.file_menu = wx.Menu()
	self.menubar.Append(self.file_menu, '&File')
	quit_item = self.file_menu.Append(wx.ID_EXIT, 'Quit', 'Quit Program')
	self.Bind(wx.EVT_MENU, self.on_exit, quit_item)
	self.SetMenuBar(self.menubar)

        panel = wx.Panel(self)

        hbox = wx.BoxSizer(wx.HORIZONTAL)	#main box
	vbox0 = wx.BoxSizer(wx.VERTICAL)	#Checkbox Box (left side)
	vbox1 = wx.BoxSizer(wx.VERTICAL)	#graph figure box
	vbox2 = wx.BoxSizer(wx.VERTICAL)	#controls box
	vbox3 = wx.BoxSizer(wx.VERTICAL)	#Company info box
	#hbox2 = wx.BoxSizer(wx.HORIZONTAL)	#checkbox box
	hbox3 = wx.BoxSizer(wx.HORIZONTAL)	#Box for buttons above graph


	vbox0.SetMinSize([100,100])		#Set min size for tree control area
	vbox2.SetMinSize([300,100])

	hbox.Add(vbox0, 0, flag=wx.EXPAND | wx.LEFT)
	hbox.Add(vbox1, 1, flag=wx.EXPAND | wx.LEFT)
	hbox.Add(vbox2, 0,  wx.EXPAND)
	
	#Graph Area
	self.live = wx.ToggleButton(panel, -1, 'Live Update  ')
	hbox3.Add(self.live, 0, flag=wx.ALIGN_RIGHT)

	self.oneD_button = wx.ToggleButton(panel, -1, '1 day')
	self.oneD_button.Bind(wx.EVT_TOGGLEBUTTON, self.on_go)
	hbox3.Add(self.oneD_button, 0, flag=wx.ALIGN_RIGHT)
	self.twoD_button = wx.ToggleButton(panel, -1, '2 days')
	self.twoD_button.Bind(wx.EVT_TOGGLEBUTTON, self.on_go)
	hbox3.Add(self.twoD_button, 0, flag=wx.ALIGN_RIGHT)
	self.oneW_button = wx.ToggleButton(panel, -1, '1 week')
	self.oneW_button.Bind(wx.EVT_TOGGLEBUTTON, self.on_go)
	hbox3.Add(self.oneW_button, 0, flag=wx.ALIGN_RIGHT)
	self.oneM_button = wx.ToggleButton(panel, -1, '1 month')
	self.oneM_button.Bind(wx.EVT_TOGGLEBUTTON, self.on_go)
	hbox3.Add(self.oneM_button, 0, flag=wx.ALIGN_RIGHT)
	self.oneY_button = wx.ToggleButton(panel, -1, '1 year')
	self.oneY_button.Bind(wx.EVT_TOGGLEBUTTON, self.on_go)
	self.oneY_button.SetValue(True)
	hbox3.Add(self.oneY_button, 0, flag=wx.ALIGN_RIGHT)
	self.fiveY_button = wx.ToggleButton(panel, -1, '5 years')
	self.fiveY_button.Bind(wx.EVT_TOGGLEBUTTON, self.on_go)
	hbox3.Add(self.fiveY_button, 0, flag=wx.ALIGN_RIGHT)
	vbox1.Add(hbox3, 0, flag=wx.ALIGN_RIGHT)	

	self.figure = Figure()
	self.ax1 = self.figure.add_subplot(111)
	self.ax1.yaxis.tick_right()
	self.figure.patch.set_visible(True)
	self.canvas = FigCanvas(panel, -1, self.figure)
	vbox1.Add(self.canvas, 1, wx.RIGHT | wx.EXPAND)
	
        self.toolbar = NavigationToolbar2Wx(self.canvas)
	vbox1.Add(self.toolbar, 0, wx.LEFT, 10)

	#Right side area
        m_text = wx.StaticText(panel, -1, "Stock Symbol:       ")
        m_text.SetFont(wx.Font(14, wx.SWISS, wx.NORMAL, wx.BOLD))
        m_text.SetSize(m_text.GetBestSize())
        vbox2.Add(m_text, 0, wx.LEFT, 10)
	
	hbox_symbol = wx.BoxSizer(wx.HORIZONTAL)
	vbox2.Add(hbox_symbol, 0, wx.ALL, 10)
	self.stock_textbox = wx.TextCtrl(panel, -1, size=(125, -1))
	self.go_button = wx.Button(panel, 1, 'Go') 
	self.go_button.Bind(wx.EVT_BUTTON, self.on_go)
	hbox_symbol.Add(self.stock_textbox, 0)
	hbox_symbol.Add(self.go_button, 0)
	


	
	self.name_text = wx.StaticText(panel, -1, '        ')
	self.name_text.SetFont(wx.Font(12, wx.SWISS, wx.NORMAL, wx.BOLD))
	self.sym_text = wx.StaticText(panel, -1, '      ')
	self.price_text = wx.StaticText(panel, -1, '             ')
	self.price_text.SetFont(wx.Font(20, wx.SWISS, wx.NORMAL, wx.NORMAL))
	self.change_text = wx.StaticText(panel, -1, '       ')
	self.ask_text = wx.StaticText(panel, -1, '          ')
	self.bid_text = wx.StaticText(panel, -1, '    ')
	self.date_text = wx.StaticText(panel, -1, '          ')
	self.time_text = wx.StaticText(panel, -1, '     ')
	self.range_text = wx.StaticText(panel, -1, '     ')
	self.fiftytwo_week_text = wx.StaticText(panel, -1, '')
	self.open_text = wx.StaticText(panel, -1, '')
	self.avg_vol_text = wx.StaticText(panel, -1, '')
	self.mkt_cap_text = wx.StaticText(panel, -1, '')
	self.eps_text = wx.StaticText(panel, -1, '')
	self.pe_text = wx.StaticText(panel, -1, '')
	self.pb_text = wx.StaticText(panel, -1, '')
	self.ps_text = wx.StaticText(panel, -1, '')
	self.target_1yr_text = wx.StaticText(panel, -1, '')
	self.prev_close_text = wx.StaticText(panel, -1, '')
	self.dividend_text = wx.StaticText(panel, -1, '')
	self.dividend_yield_text = wx.StaticText(panel, -1, '')

	self.ask_label = wx.StaticText(panel, -1, 'ask ')
	self.bid_label = wx.StaticText(panel, -1, 'bid ')
	self.range_label = wx.StaticText(panel, -1, 'Range')
	self.range_label.SetForegroundColour((110,110,110))
	self.fiftytwo_week_label = wx.StaticText(panel, -1, '52 Week')
	self.fiftytwo_week_label.SetForegroundColour((110,110,110))
	self.open_label = wx.StaticText(panel, -1, 'Open')
	self.open_label.SetForegroundColour((110,110,110))
	self.avg_vol_label = wx.StaticText(panel, -1, 'Avg Vol')
	self.avg_vol_label.SetForegroundColour((110,110,110))
	self.mkt_cap_label = wx.StaticText(panel, -1, 'Mkt Cap')
	self.mkt_cap_label.SetForegroundColour((110,110,110))
	self.eps_label = wx.StaticText(panel, -1, 'EPS')
	self.eps_label.SetForegroundColour((110,110,110))
	self.pe_label = wx.StaticText(panel, -1, 'P/E')
	self.pe_label.SetForegroundColour((110,110,110))
	self.pb_label = wx.StaticText(panel, -1, 'P/B')
	self.pb_label.SetForegroundColour((110,110,110))
	self.ps_label = wx.StaticText(panel, -1, 'P/S')
	self.ps_label.SetForegroundColour((110,110,110))
	self.target_1yr_label = wx.StaticText(panel, -1, '1yr Target')
	self.target_1yr_label.SetForegroundColour((110,110,110))
	self.prev_close_label = wx.StaticText(panel, -1, 'Prev Close')
	self.prev_close_label.SetForegroundColour((110,110,110))
	self.dividend_label = wx.StaticText(panel, -1, 'Div/Share')
	self.dividend_label.SetForegroundColour((110,110,110))
	self.dividend_yield_label = wx.StaticText(panel, -1, 'Div Yield')
	self.dividend_yield_label.SetForegroundColour((110,110,110))

	vbox_name_sym = wx.BoxSizer(wx.VERTICAL)
	hbox_price = wx.BoxSizer(wx.HORIZONTAL)
	vbox_price = wx.BoxSizer(wx.VERTICAL)
	vbox_change = wx.BoxSizer(wx.VERTICAL)
	hbox_ask_bid = wx.BoxSizer(wx.HORIZONTAL)
	hbox_ask = wx.BoxSizer(wx.HORIZONTAL)
	hbox_bid = wx.BoxSizer(wx.HORIZONTAL)
	hbox_date = wx.BoxSizer(wx.HORIZONTAL)
	vbox_date = wx.BoxSizer(wx.VERTICAL)
	vbox_time = wx.BoxSizer(wx.VERTICAL)
	hbox_labels = wx.BoxSizer(wx.HORIZONTAL)
	vbox_labels = wx.BoxSizer(wx.VERTICAL)
	vbox_text = wx.BoxSizer(wx.VERTICAL)

	vbox2.Add(vbox_name_sym, 0, wx.ALL, 5)
	vbox2.Add(hbox_price, 0, flag=wx.ALIGN_LEFT)
	hbox_price.Add(vbox_price, 0, wx.LEFT, 5 | wx.RIGHT, 5)
	hbox_price.Add(vbox_change, 0, wx.LEFT, 5 | wx.RIGHT, 5)
	vbox2.Add(hbox_date, 0, wx.ALL, 5)
	hbox_date.Add(vbox_date, 0, wx.LEFT, 5 | wx.RIGHT, 5)
	hbox_date.Add(vbox_time, 0, wx.LEFT, 5 | wx.RIGHT, 5)
	vbox2.Add(hbox_ask_bid, 0)
	hbox_ask_bid.Add(hbox_ask, 0, wx.ALL, 10)
	hbox_ask_bid.Add(hbox_bid, 0, wx.ALL, 10)
	vbox2.Add(hbox_labels, 0)
	hbox_labels.Add(vbox_labels, 0, wx.ALL, 10)
	hbox_labels.Add(vbox_text, 0, wx.ALL, 10)


	vbox_name_sym.Add(self.name_text, 0)
	vbox_name_sym.Add(self.sym_text, 0)
	vbox_price.Add(self.price_text, 0)
	vbox_change.Add(self.change_text, 0)
	hbox_ask.Add(self.ask_label, 0)
	hbox_ask.Add(self.ask_text, 0)
	hbox_bid.Add(self.bid_label, 0)
	hbox_bid.Add(self.bid_text, 0)
	vbox_date.Add(self.date_text, 0)
	vbox_time.Add(self.time_text, 0)
	vbox_labels.Add(self.prev_close_label, 0)
	vbox_labels.Add(self.range_label, 0)
	vbox_labels.Add(self.fiftytwo_week_label, 0)
	vbox_labels.Add(self.open_label, 0)
	vbox_labels.Add(self.avg_vol_label, 0)
	vbox_labels.Add(self.mkt_cap_label, 0)
	vbox_labels.Add(self.eps_label, 0)
	vbox_labels.Add(self.pe_label, 0)
	vbox_labels.Add(self.pb_label, 0)
	vbox_labels.Add(self.ps_label, 0)
	vbox_labels.Add(self.target_1yr_label, 0)
	vbox_labels.Add(self.dividend_label, 0)
	vbox_labels.Add(self.dividend_yield_label, 0)
	vbox_text.Add(self.prev_close_text, 0)
	vbox_text.Add(self.range_text, 0)
	vbox_text.Add(self.fiftytwo_week_text, 0)
	vbox_text.Add(self.open_text, 0)
	vbox_text.Add(self.avg_vol_text, 0)
	vbox_text.Add(self.mkt_cap_text, 0)
	vbox_text.Add(self.eps_text, 0)
	vbox_text.Add(self.pe_text, 0)
	vbox_text.Add(self.pb_text, 0)
	vbox_text.Add(self.ps_text, 0)
	vbox_text.Add(self.target_1yr_text, 0)
	vbox_text.Add(self.dividend_text, 0)
	vbox_text.Add(self.dividend_yield_text, 0)




	#Checkbox area
	cb_label1 = wx.StaticText(panel, -1, 'Data')
	vbox0.Add(cb_label1, 0, wx.LEFT, 10)
	self.cb_data1 = wx.CheckBox(panel, -1, 'Raw')
	self.cb_data1.SetValue(True)
	vbox0.Add(self.cb_data1, 0, wx.LEFT, 10)
	self.cb_data2 = wx.CheckBox(panel, -1, 'Smoothed')
	vbox0.Add(self.cb_data2, 0, wx.LEFT, 10)
	cb_label2 = wx.StaticText(panel, -1, 'Indicators')
	vbox0.Add(cb_label2, 0, wx.LEFT, 10)
	self.cb_ind0 = wx.CheckBox(panel, -1, 'Min/Max')
	self.cb_ind0.SetValue(True)
	vbox0.Add(self.cb_ind0, 0, wx.LEFT, 10)
	self.cb_ind1 = wx.CheckBox(panel, -1, '5 Day Moving Average')
	vbox0.Add(self.cb_ind1, 0, wx.LEFT, 10)
	self.cb_ind2 = wx.CheckBox(panel, -1, '21 Day Moving Average')
	vbox0.Add(self.cb_ind2, 0, wx.LEFT, 10)
	self.cb_ind3 = wx.CheckBox(panel, -1, 'Bollinger Bands')
	vbox0.Add(self.cb_ind3, 0, wx.LEFT, 10)
	cb_label3 = wx.StaticText(panel, -1, 'Manipulations')
	vbox0.Add(cb_label3, 0, wx.LEFT, 10)
	self.cb_man1 = wx.CheckBox(panel, -1, 'Derivative')
	vbox0.Add(self.cb_man1, 0, wx.LEFT, 10)
	self.cb_man2 = wx.CheckBox(panel, -1, '2nd Derivative')
	vbox0.Add(self.cb_man2, 0, wx.LEFT, 10)

	hbox.Fit(self)
        panel.SetSizer(hbox)
        panel.Layout()

	self.live_val = 0
	#Convert dates to uniform spacing, so plots don't display weekends or market holidays
    def format_date(self, x, pos=None):
	thisind = np.clip(int(x+0.5), 0, self.N-1)
	return self.data.date[thisind].strftime('%Y-%m-%d')

	#This method is run in a second thread to monitor the status of the "Live Update" button
    def check_live(self):
	while(1):
		if self.live.GetValue():
			self.live.SetBackgroundColour(wx.Colour(0,224,56))
			with threading.RLock():					#Probably don't need in this scope, but kept it anyways
				self.live_val = 1
				wx.CallAfter(self.on_go)			#No idea why this works
		else:
			self.live.SetBackgroundColour(wx.Colour(220,220,220, 255))
			self.live_val = 0
		time.sleep(30)


    def draw_graph(self, event=None):	
	self.ax1.clear()
	self.ax1.xaxis.set_major_formatter(ticker.FuncFormatter(self.format_date))
	self.ax1.set_xlim(self.ind[0], max(self.ind))
	plt.setp(self.ax1.xaxis.get_majorticklabels(), rotation=30)
	self.ax1.grid(b=True, which='major')
	
	#Check for which type of plot to make:
	if self.cb_data1.GetValue():
		self.ax1.plot(self.ind, self.data.close_val, color='blue', linewidth=2.0)
	if self.cb_data2.GetValue():
		self.ax1.plot(self.ind, self.data.smoothed_close, color='red')
	if self.cb_ind0.GetValue():
		self.ax1.axhline(y=max(self.data.close_val), color = 'black', linestyle = '--')
		self.ax1.axhline(y=min(self.data.close_val), color = 'black', linestyle = '--')
	if self.cb_ind1.GetValue():
		self.ax1.plot(self.ind, self.data.close_5day, label='5 Day Moving Average', color='green')
		self.ax1.set_xlim(self.ind[0]+6, max(self.ind))
	if self.cb_ind2.GetValue():
		self.ax1.plot(self.ind, self.data.close_21day, label='21 Day Moving Average', color='purple')
		self.ax1.set_xlim(self.ind[0]+30, max(self.ind))
	if self.cb_ind3.GetValue():
		self.ax1.plot(self.ind, self.data.upper_bollinger_band, color='green', linewidth=2.0)
		self.ax1.plot(self.ind, self.data.lower_bollinger_band, color='red', linewidth = 2.0)
		self.ax1.plot(self.ind, self.data.close_20day, color = 'black', linewidth = 1.0)
		self.ax1.set_xlim(self.ind[0]+25, max(self.ind))
	self.ax1.set_ylim(min(self.data.close_val)*0.99, max(self.data.close_val)*1.01)

	if self.cb_man1.GetValue():
		self.ax1.plot(self.ind, self.data.derivative_close, label='Derivative')
		self.ax1.set_ylim(min(self.data.derivative_close), max(self.data.derivative_close))
	if self.cb_man2.GetValue():
		self.ax1.plot(self.ind, self.data.second_derivative_close, label='2nd Derivative')
		self.ax1.set_ylim(min(self.data.second_derivative_close), max(self.data.second_derivative_close))
	
	self.ax1.legend()
	self.canvas.draw()
	

    def on_exit(self, event):
	self.Destroy()

    def on_go(self, event=None):
	
	stock_symbol = self.stock_textbox.GetValue()
	if self.live_val:
		self.data = Data(stock_symbol, '1 day')				#Right now, only display 1 day worth of data during the Live Update Mode
	else:
		#Check what time-range to get data for
		obj = event.GetEventObject()
		button_ID = obj.GetLabel()
		for button in [self.oneD_button, self.twoD_button, self.oneW_button, self.oneM_button, self.oneY_button, self.fiveY_button]:
			if button.GetLabel() != button_ID and button_ID != 'Go':
				button.SetValue(False)
				button.SetBackgroundColour(wx.Colour(220,220,220,255))
		obj.SetBackgroundColour(wx.Colour(223, 165, 9))

		
		if button_ID == 'Go':
			self.data = Data(stock_symbol, '1 year')		#Go button loads 1 year of data automatically
		else:
			self.data = Data(stock_symbol, button_ID)
		#Grey out moving avereages for time periods with too-few data points
		if button_ID in ['1 day', '2 days', '1 week', '1 month']:
			self.cb_ind1.Enable(False)
			self.cb_ind2.Enable(False)
			self.cb_ind3.Enable(False)
		else:
			self.cb_ind1.Enable(True)
			self.cb_ind2.Enable(True)
			self.cb_ind3.Enable(True)
	
	self.N = len(self.data.date)
	self.ind = np.arange(self.N)
	
	self.draw_graph()
	
		#Update company info textboxes
	self.name_text.SetLabel(self.data.name)
	self.sym_text.SetLabel(self.data.exchange+':'+self.data.sym)
	self.price_text.SetLabel(self.data.price)
	self.change_text.SetLabel(self.data.change + ' ('+self.data.change_percent + ')')
	if float(self.data.change[:5]) > 0:
		self.change_text.SetForegroundColour((0, 224, 56))
	
	else:
		self.change_text.SetForegroundColour((250, 0, 0))
	self.ask_text.SetLabel(self.data.ask)
	self.bid_text.SetLabel(self.data.bid)
	self.date_text.SetLabel(self.data.trade_date)
	self.time_text.SetLabel(' - '+self.data.trade_time)
	self.range_text.SetLabel(self.data.day_low+' - '+self.data.day_high)
	self.fiftytwo_week_text.SetLabel(self.data.fiftytwo_week_low+' - '+self.data.fiftytwo_week_high)
	self.open_text.SetLabel(self.data.open_val)
	self.avg_vol_text.SetLabel(self.data.avg_daily_vol)
	self.mkt_cap_text.SetLabel(self.data.mkt_cap)
	self.eps_text.SetLabel(self.data.eps)
	self.pe_text.SetLabel(self.data.pe)
	self.pb_text.SetLabel(self.data.pb)
	self.ps_text.SetLabel(self.data.ps)	
	self.target_1yr_text.SetLabel(self.data.target_1yr)
	self.prev_close_text.SetLabel(self.data.prev_close)
	self.dividend_text.SetLabel(self.data.dividend)
	self.dividend_yield_text.SetLabel(self.data.dividend_yield + '%')

if __name__ == '__main__':
    app = wx.PySimpleApp()
    app.frame = GraphFrame()
    app.frame.Maximize()
    app.frame.Show()
    t1 = threading.Thread(target=app.frame.check_live)
    t1.daemon = True
    t1.start()
    app.MainLoop()
    




