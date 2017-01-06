# Store Management
My submission for McCoy's Coding Challenge

Allows for the management of store information.

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
