from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.common.keys import Keys
from bs4 import BeautifulSoup
from time import sleep
from openpyxl import Workbook

navegador = webdriver.Chrome()
lista_produtos = []

maiorPreco = 0
menorPreço = float('inf') 
mediaPreços = 0
soma = 0

url = "https://www.mercadolivre.com.br/"
pesquisa = "notebook 16gb RAM e 1TB SSD"

navegador.get(url)

barra_pesquisa = navegador.find_element(By.ID, 'cb1-edit')
barra_pesquisa.send_keys(pesquisa)
barra_pesquisa.send_keys(Keys.ENTER)
sleep(2)

site = BeautifulSoup(navegador.page_source, 'html.parser')
produtos = site.find_all('div', attrs={
    'class': 'ui-search-result__wrapper'
})

while len(lista_produtos) < 20:
    for produto in produtos[:20]:
        marca = produto.find('span', attrs={
            'class': 'poly-component__brand'
        })

        nome_produto = produto.find('a', attrs={
            'class': 'poly-component__title'
        })

        vendedor = produto.find('span', attrs={
            'class': 'poly-component__seller'
        })

        preco = produto.find('span', attrs={
            'class': 'andes-money-amount__fraction'
        })

        avaliacao = produto.find('span', attrs={
            'class': 'poly-reviews__rating'
        })

        if marca and nome_produto and vendedor and preco and avaliacao:
            precoValor = float(preco.text.strip().replace('R$', '').replace('.', '').replace(',', '.').strip())

            soma += precoValor

            if precoValor > maiorPreco:
                maiorPreco = precoValor
            if precoValor < menorPreço: 
                menorPreço = precoValor
            
            item = {
                'marca': marca.text.strip(),
                'nome': nome_produto.text.strip(),
                'vendedor': vendedor.text.strip(),
                'preço': precoValor,
                'avaliação': avaliacao.text.strip()
            }
            lista_produtos.append(item)
            print("\n", item)
        
        if len(lista_produtos) >= 20:
            break

print("\nTotal de produtos coletados:", len(lista_produtos))

if len(lista_produtos) > 0:
    mediaPreços = soma / len(lista_produtos)

print("\n\nMaior preço: ", maiorPreco)
print("Menor preço: ", menorPreço)
print("Média de preços: ", mediaPreços)

wb = Workbook()
ws = wb.active
ws.title = "Produtos"

ws.append(['Marca', 'Nome', 'Vendedor', 'Preço', 'Avaliação'])

for produto in lista_produtos:
    ws.append([produto['marca'], produto['nome'], produto['vendedor'], produto['preço'], produto['avaliação']])

ws_precos = wb.create_sheet(title="Preços Mercado Livre")
ws_precos.append(['Maior Preço', 'Menor Preço', 'Média de Preços'])
ws_precos.append([maiorPreco, menorPreço, mediaPreços])

wb.save("Produtos.xlsx")

navegador.quit()
