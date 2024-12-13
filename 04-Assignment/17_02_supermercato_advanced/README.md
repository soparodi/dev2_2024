# SUPERMERCATO ADVANCED

Implementare le entità che compongono un supermercato.

> Partendo dalla soluzione dell'esercizio `28_classi-9` implementare le seguenti entità:
- **Dipendente:** rappresenta un dipendente del supermercato.

Oltre ai campi già presenti (ID, nome, cognome), aggiungere un campo `ruolo` di tipo `String` che rappresenta il ruolo del dipendente
(es. "cassiere", "magazziniere", "direttore", ecc.).

Implementare i metodi `getRuolo` e `setRuolo`.
- **Cassiere:** può registrare i prodotti acquistati da un cliente e calcolare il totale da pagare.
- **Magazziniere:** può aggiungere o rimuovere prodotti dal magazzino.
- **Amministratore:** rappresenta un amministratore del supermercato. Un amministratore è un dipendente con ruolo "amministratore". Può impostare il ruolo dei dipendenti.