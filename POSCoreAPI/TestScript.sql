TEST SCRIPT:



REQUEST CREATEPOSUSERS: http://localhost:8422/api/pos/CreatePOSUsers


{
	"Name":"TESTDEMOUSER5",
	"PIN":"2000"
}

REQUEST CREATEPOSTICKETS: http://localhost:8422/api/pos/CreatePOSTickets?userid=8


{
  "tableName": "tbl13",
  "tableNumber": 8,
  "departmentId": 6546,
  "guestCount": 2,
  "balance": 20.00,
  "ticketAlerts": "none",
  "flags": "none",
  "options":"none"
}

REQUEST CREATEPOSORDER: http://localhost:8422/api/pos/CreatePOSOrders/ticketId=5&orderId=0


[
  {
	  "ItemDescription": "burger",
	  "ItemPrice": 9.00
  },
  {
	  "ItemDescription": "fries and drink",
	  "ItemPrice": 9.00
  }
]




REQUEST LOGINDATA: http://localhost:8422/api/pos/GetLoginData


{"Data":"2000","ID":13,"Method":0}

REQUEST GETTICKETS: http://localhost:8422/api/pos/GetTickets/filter=0


{"ID":13,"Name":"TESTDEMOUSER5","PIN":"2000","Permissions":0}

REQUEST GETTICKETSBYNAME: http://localhost:8422/api/pos/GetTicketByName/name=tbl13


{"ID":13,"Name":"TESTDEMOUSER5","PIN":"2000","Permissions":0}

REQUEST GETTICKETSBYID: http://localhost:8422/api/pos/GetTicketById/filter=0&Id=13


{"ID":13,"Name":"TESTDEMOUSER5","PIN":"2000","Permissions":0}

REQUEST APPLYPAYMENT: http://localhost:8422/api/pos/PostApplyPayment


{
	"User":{
		"ID":13,
		"Name":"TESTDEMOUSER5",
		"PIN":"2000",
		"Permissions":0
	},
	"Ticket":{
		"Balance":20.00,
		"CreatedTime":"2015-06-12T12:28:50.2500000-07:00",
		"Flags":0,
		"GuestCount":2,
		"ID":13,
		"Name":"tbl8",
		"Number":"107508",
		"Owner":{
			"ID":13,
			"Name":"TESTDEMOUSER5",
			"PIN":"2000",
			"Permissions":0
		},
		"PaymentsTotal":20,
		"TicketAlerts":4,
		"User":{
			"ID":13,
			"Name":"TESTDEMOUSER5",
			"PIN":"2000",
			"Permissions":0
		}
	},
	"POSTenderType":"AMEX_R",
	"Amount":20.00,
	"Tip":0.00,
	"TransactionCode":"null-17848fdbcf",
	"PrintingInfo":{
		"Name":"Epson",
		"ID":"1",
		"SplitType":0,
		"IsFinal":1
	},
	"CardData":{
		"CardType":"AMEX",
		"ClearText":"C135",
		"CreditType":"CREDIT",
		"DeviceSerialNumber":"B048D36110811AA",
		"DUKPTSerialNumber":"9011880B048D360002B7",
		"EncryptedCRC":"",
		"EncryptedMagnePrint":"F8B413422BF212CFF4C623FBAC5DE2C35F5B1DCB77E0BD733F2F01EA797ED6048F2FBEEDEF307350EB1D945D19A60549780DA9CAAE6174B0",
		"EncryptedSessionID":"15F72A0069DE16A3",
		"EncryptedTrack1":"001af001",
		"EncryptedTrack2":"674842EEBB874F72A5A19CE3330816770701C5F80112C25025BB96CD8BCE43655EA31D2E8961D6C0",
		"EncryptedTrack3":"",
		"ExpMonth":"01",
		"ExpYear":"19",
		"FormatCode":"0000",
		"IsTestCard":false,
		"MagnePrint":"61400200",
		"MaskedTrack1":"%371449635398431^SMITH3/JOE^1901012000000001230000?",
		"MaskedTrack2":";371400070008431=19010000000000000000?",
		"MaskedTrack3":null,
		"Name":"SMITH3/JOE",
		"PanHash":"371400070008431",
		"PANLast4":"8431",
		"POSTenderType":"AMEX_R",
		"ReaderEncryptedStatus":"0600"
	},
	"AuthCode":"null-04cbeffd63"
}

REQUEST SETTLETICKET: http://localhost:8422/api/pos/PostSettleTicket


{
    "userAccount": {
		"ID":13,
		"Name":"TESTDEMOUSER5",
		"PIN":"2000",
		"Permissions":0
    },
	"Ticket":{
		"Balance":20.00,
		"CreatedTime":"2015-06-12T12:28:50.2500000-07:00",
		"Flags":0,
		"GuestCount":1,
		"ID":5,
		"Name":"tbl8",
		"Number":"107508",
		"Owner":{
			"ID":13,
			"Name":"TESTDEMOUSER5",
			"PIN":"2000",
			"Permissions":0
		},
		"PaymentsTotal":20,
		"TicketAlerts":4,
		"User":{
			"ID":13,
			"Name":"TESTDEMOUSER5",
			"PIN":"2000",
			"Permissions":0
		}
	}
} 

REQUEST PRINTRECEIPT: http://localhost:8422/api/pos/PostPrintReceipt  


{
        "PrinterID":1,
        "Header":"12220 113th Ave. Suite 210, Kirkland, WA 98037",
        "Footer":"Printed from the RAIL",
        "Payment":{
            "type":"card",
            "POSTenderType":"AMEX_R",
            "TransactionCode":"A11A8C251980",
            "AuthCode":"8aa46349ba",
            "CardData":{
                "CardType":"AMEX",
                "ClearText":"C135",
                "CreditType":"CREDIT",
                "DUKPTSerialNumber":"9011880B048D360002B7",
                "DeviceSerialNumber":"B048D36110811AA",
                "EncryptedCRC":"",
                "EncryptedMagnePrint":"F8B413422BF212CFF4C623FBAC5DE2C35F5B1DCB77E0BD733F2F01EA797ED6048F2FBEEDEF307350EB1D945D19A60549780DA9CAAE6174B0",
                "EncryptedSessionID":"15F72A0069DE16A3",
                "EncryptedTrack1":"001af001",
                "EncryptedTrack2":"674842EEBB874F72A5A19CE3330816770701C5F80112C25025BB96CD8BCE43655EA31D2E8961D6C0",
                "EncryptedTrack3":"",
                "ExpMonth":"01",
                "ExpYear":"19",
                "FormatCode":"0000",
                "MagnePrint":"61400200",
                "MaskedTrack1":"%371449635398431^SMITH3/JOE^1901012000000001230000?",
                "MaskedTrack2":";371400070008431=19010000000000000000?",
                "MaskedTrack3":null,
                "Name":"SMITH3/JOE",
                "PANLast4":"8431",
                "POSTenderType":"AMEX_R",
                "PanHash":"371400070008431",
                "ReaderEncryptedStatus":"0600"
            }
        },
        "Bill":{
            "DiscountTotal":0,
            "GratuityTotal":0,
            "ServiceChargeTotal":0,
            "Subtotal":18.00,
            "TaxTotal":1.00,
            "TipTotal":1.00,
            "Total":20.00
        },
        "Order":{
            "Items":[
                {
                "Description":"Burger",
                "ID":1147161,
                "Modifiers":[
                ],
                "Price":9.00
                },
                {
                "Description":"Fries and Drink",
                "ID":1147170,
                "Modifiers":[
                ],
                "Price":9.00
                }
            ],
            "Tip":2.00
        },
        "Format":0,
        "Ticket":{
            "Balance":20.00,
            "CreatedTime":"2016-02-08T13:11:24.0000000",
            "DepartmentID":0,
            "Flags":0,
            "GuestCount":0,
            "ID":1049519,
            "Name":"Table 56\/1",
            "Number":"10943",
            "Owner":{
				"ID":13,
				"Name":"TESTDEMOUSER5",
				"PIN":"2000",
				"Permissions":0
            },
            "PaymentsTotal":20.0,
            "TableID":0,
            "TicketAlerts":0,
            "User":{
				"ID":13,
				"Name":"TESTDEMOUSER5",
				"PIN":"2000",
				"Permissions":0
            }
        },
        "Options":0
}


REQUEST GETPOSSTATUS: http://localhost:8422/api/pos/GetPOSStatus 












REQUEST CREATEPOSPAYMENTS:http://localhost:8422/api/pos/CreatePOSPayments/ticketId=1
{
  "gatewayPaymentId": 1,
  "authCode": "test",
  "transactionCode": "test",
  "postenderType": "credit card",
  "subtotal": 18.00,
  "taxTotal": 1.00,
  "tipTotal": 1.00,
  "paymentTotal": 20.00
}

REQUEST CREATEPOSCREDITCARDS: http://localhost:8422/api/pos/CreatePOSCreditCards/paymentId=1
{
  "cardType": "VISA",
  "panHash": "371400070008431",
  "panLast4": "8431",
  "expYear": "19",
  "expMonth": "01"
}

