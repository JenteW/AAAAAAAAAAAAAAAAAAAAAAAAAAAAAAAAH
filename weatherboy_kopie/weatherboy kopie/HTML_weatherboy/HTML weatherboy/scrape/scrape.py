import requests
from bs4 import BeautifulSoup
import pandas as pd

# URL of the page you want to scrape
url = 'https://www.ah.be/producten/vlees-kip-vis-vega'

# Make a request to the website
r = requests.get(url)

# Initialize BeautifulSoup
soup = BeautifulSoup(r.text, 'html.parser')

# Find elements containing product information - adjust the selector as needed
products = soup.findAll('div', {'class': 'product-selector-class'})

data = []

# Loop through each product and extract information
for product in products:
    name = product.find('h3', {'class': 'product-name-class'}).text.strip()
    price = product.find('span', {'class': 'price-class'}).text.strip()
    data.append([name, price])

# Create a DataFrame and save to Excel
df = pd.DataFrame(data, columns=['Product Name', 'Price'])
df.to_excel('products_prices.xlsx', index=False)
