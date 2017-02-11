# Utgiftskollen (Finances.NET)

Small personal finances application in .NET, a spare time project that i worked on 2 years ago.

# Features:
Based on the double-entry system. (Credit/Debit)

Internationalization (English,German and Swedish localization).

Filtering of transactions.

2 types of charts for the moment (Piechart and linechart).

Can handle multiple accounts at the same time.

Can handle multiple currencies (when changing currencies fetches the exchange rate and recalculates the transaction sums in the new currency).

Users can add their own budget categories.

Rijndael data encryption,256 bits standard but can be altered under settings to 128 bits or 192 bits instead. (experimental).

Export transactions to excel. (Open XML SDK)

Import of transactions from excel file, has datamaping, excel exports from different banks can be used.

XML file save/load.

Has a Plugin system, for the moment there are just 3 plugins, 2 chart plugins each for a specific chart type and 1 report plugin that displays an transactions report. (Not localized, so the report plugin is only in English for the moment)

Plugins are automatically loaded on startup, to add a plugin you just have to copy the plugin .dll file into the plugins directory.

Monthly transactions.


# Future development :
Automatic updating.

More budgeting functions.

More plugins.


# DISCLAIMER:
# THIS APPLICATION COMES WITH NO WARRANTY AT ALL, NEITHER EXPRESS NOR IMPLIED. I DO NOT TAKE ANY RESPONSIBILITY FOR ANY DAMAGE TO YOUR COMPUTER BECAUSE OF IMPROPER USAGE OF THIS SOFTWARE. UTGIFTSKOLLEN (FINANCES.NET) IS AN ONGOING PROJECT SO FEEL FREE TO PROVIDE FEEDBACK AND REPORT ISSUES.
