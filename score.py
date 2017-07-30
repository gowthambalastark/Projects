import requests
from bs4 import BeautifulSoup
import subprocess
import time
import os
 
url = "http://www.espncricinfo.com/ci/engine/match/index.html?view=live"
html = requests.get(url).text
soup = BeautifulSoup(html, "lxml")
for i in soup.findAll("section",{"class":"matches-day-block"}):
    t=str(i.text).replace('\n','').replace('\r','')
    print(t)
    t='"'+t+'"'
    textt="espeak "+t
    subprocess.Popen(['notify-send', t])
    os.system(textt)
    time.sleep(10)
       