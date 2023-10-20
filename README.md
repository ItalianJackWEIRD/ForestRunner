# Jack-on-The-Run
Gioco mobile creato.
Istruzioni per scaricare il progetto sul proprio computer:

1) Creare una cartella Progetti sul proprio computer (consiglio direttamente su /C:) e lasciarla vuota.
2) Clonare il progetto da Git Desktop nella cartella "Progetti" in modo da avere cosi una cartella "Jack-on-The-Run" con dentro soltanto i file "Gitignore" "Readme" e le cartelle "Assets" e "ProjectSettings".
3) Creare in Unity un nuovo progetto dove si vuole sul proprio computer MA NON nella cartella "Progetti" creata precedentemente (Versione di Unity 2022.3.10f1) e importare dalle impostazioni iniziali (prima di creare il progetto vero e proprio) le utilità per sviluppare su Android e IOS.
4) Andare alla cartella del progetto appena creato vuoto e copiare tutti i file tranne le cartelle "Assets", "ProjectSettings" e "UpgradeLog.html" dentro la cartella di Git "Jack-on-The-Run".
5) Aprire Unity Hub, cliccare su Open Project e selezionare la cartella di Git "Jack-on-The-Run".
6) Inizia a programmare :D !!!


ISTRUZIONI PER BUILDARE SU ANDROID STUDIO

Per creare un APK con Android Studio, prima bisogna esportare il progetto da Unity:
	vai su "File/Build Settings" e dopo aver selezionato Android, fare check sulle due caselle chiamate "Export project" e "Export
	for App Bundle".
	
	Dopodichè clicca su export, selezionando una cartella appena creata VUOTA. 
	Poi aprire Android Studio, andare su "File/ New/ Import Project" e selezionare quella cartella appena creata sulla quale si ha
	esportato il progetto.
	Poi andare su "Build/ Build Bundle(s)|Apk(s) / Build Apk" e verranno fuori 2 errori da dover correggere a livello di codice.
	Cambiare le due righe di codice che daranno errore in questo :

	if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.BASE)
            permissionGranted = true;

	basta cambiare "VERSION_CODES.TIRAMISU" in ".BASE" e mettere la variabile "permissionGranted = ecc..." in " = true;" .
	Per trovare la Apk, essa sarà nella cartella esportata da Unity, nelle sottocartelle  :
	"C:\Users\TUONOMEUTENTE\TUADIRECTORY\ ecc \NOMEPROGETTTO\launcher\build\outputs\apk\debug"
