**Hämta det befintliga API-projektet**
    
1. - Starta med den kod du fått, testa att dina tre Bonsai-endpoints fungerar:
        - GET /api/bonsai - Hämtar alla bonsaiträd
        - GET /api/bonsai/{id} - Hämtar ett specifikt bonsaiträd
        - POST /api/bonsai - Skapar ett nytt bonsaiträd
    - Bekanta dig med hur projektet är uppdelat (Program.cs, Bonsai.cs, endpoints, etc.).
2. **Skapa/utöka klassbiblioteket**
    - Utgå från den existerande Bonsai-klassen i `OperationOOP.Core/Models/Bonsai.cs`.
    - Lägg till minst tre nya klasser i klassbiblioteket som kompletterar Bonsai-hanteringen (eller skapa en helt ny idé).
    - Använd **arv** eller **komposition** från Bonsai-klassen eller skapa en abstrakt klass (t.ex. `Plant`) och ett gemensamt Interface(exempelvis `IEntity`).
    - I klasserna ska du:
        - Använda **inkapsling** (public/private/protected).
        - Fundera på **designprinciper** (t.ex. “Single Responsibility”, “Komposition över arv när det passar” etc.).

3. **Implementera en eller flera metoder** med enklare algoritmik
    - Exempel:
        - Filtrera en lista på produkter för att hitta de med lågt lager.
        - Sök bland djur på zoo efter namn eller art.
        - Beräkna en totalsumma eller sortera objekt efter någonting (pris, antal, namn).
    - Metoden ska sedan anropas från API:t.

4. **Lägg till endpoints i API**
    - Se till att ha minst 2–3 nya endpoints, t.ex.:
        - GET för att lista eller filtrera objekt.
        - POST för att skapa ett nytt objekt i din in-memory-samling.
    - Endpoint-koden ska anropa klassbibliotekets logik.
    - Använd gärna **Dependency Injection** om du vill (ej krav, men bra övning).

5. **Testa och demonstrera**
    - Du behöver inte skriva enhetstester om det inte efterfrågas, men testa att dina endpoints fungerar – till exempel i en webbläsare, Postman, eller via inbyggda Swagger-sidor.
    - Säkerställ att dina algoritmiska metoder faktiskt fungerar (t.ex. att du får rätt filtrering eller sortering).

## Redovisning

1. **Kod** 
    - Lämna in din lösning (länk till GitHub-repo).
    - Kommentera gärna koden kortfattat för att visa ditt tänkande.

2. **Kort videogenomgång** (valfritt format)
    - Förklara hur du löst uppgiften, i en 5–10 minuters video där du delar skärmen och diskuterar koden.
    - Beskriv vilka klasser du skapade, om du använde arv/komposition & varför du valde detta.
    - Visa hur din algoritm fungerar (ex. "Så här filtreras produkterna").
    - Resonera kring eventuella designprinciper du använt (t.ex. "komposition över arv").