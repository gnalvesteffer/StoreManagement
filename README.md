# Store Management
My submission for McCoy's Coding Challenge.

Allows for the management of store information.

Demo available here: http://demo.bitdungeon.org/

Spec sheet: https://www.dropbox.com/s/a6965ai77dp0zai/McCoy%27sCodingChallenge.docx?dl=0

# Pages
| Page         | Route                | Description                                                                |
|--------------|----------------------|----------------------------------------------------------------------------|
| Home         | /                    | Displays a brief description of the site                                   |
| Store List   | /stores              | Displays a list of stores w/ links that navigate to each store detail page |
| Store Detail | /store/{storenumber} | Displays specific store detail                                             |

# API Routes
| Route                    | Method | Description                                                           |
|--------------------------|--------|-----------------------------------------------------------------------|
| /api/store/add           | POST   | Inserts a store if a store w/ that store number doesn’t already exist |
| /api/store/{storeNumber} | PUT    | Updates store w/ corresponding store number                           |
| /api/store/{storeNumber} | DELETE | Removes a store w/ corresponding store number                         |

# API Examples
- # Adding a Store
    POST to *"/api/store/add"*

    ```javascript
    {
        StoreName: "Fancy Store",
        StoreManagerName: "John Doe",
        OpeningTime: "7:00AM",
        ClosingTime: "4:00PM"
    }
    ```
- # Updating a Store
    PUT to *"/api/store/{storeNumber}"*

    Example: *"/api/store/1"*
    
    ```javascript
    {
        StoreName: "Tech Updaters",
        StoreManagerName: "Eric Smithers",
        OpeningTime: "9:00AM",
        ClosingTime: "10:00PM"
    }
    ```
    
- # Removing a Store
    DELETE to *"/api/store/{storeNumber}"*
    
    Example: *"/api/store/1"*
