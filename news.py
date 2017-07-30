import requests
from bs4 import BeautifulSoup
import subprocess
import time
import os
 
url = "https://www.techgig.com/tech-news"
html = requests.get(url).text
soup = BeautifulSoup(html, "lxml")
for i in soup.findAll("div",{"class":"news-content"}):
    t=str(i.text).strip()
    t='"'+t+'"'
    textt="espeak "+t
    subprocess.Popen(['notify-send', i.text])
    os.system(textt)
    time.sleep(8)
       