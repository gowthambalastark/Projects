from gpiozero import MotionSensor
from picamera import PiCamera
from datetime import datetime
import pathlib
import dropbox
import re
import urllib.request, urllib.parse, urllib.error, urllib.request, urllib.error, urllib.parse, http.cookiejar, sys
from time import sleep

def cook(cj):
        j=str(cj)
        t2=j.find(' for ')
        t1=int(j.find('~'))+1
        tokken=str(j[t1:t2])
        return tokken   

def sms(s):
        number=1234567890 # Way2sms_Login_Number
        password='xyz' #Login_Password
        if len(str(number))==10:
                pass
        else:
                print(" [*] Invalid Username")
                sys.exit(0)
        url='http://site24.way2sms.com/Login1.action'
        data={'username':str(number),'password':password}
        data=urllib.parse.urlencode(data)
        cj=http.cookiejar.CookieJar()
        header={'User-Agent':'Mozilla/5.0 (X11; Linux x86_64; rv:31.0) Gecko/20100101 Firefox/31.0 Iceweasel/31.8.0'}
        req=urllib.request.Request(url, data, headers=header)
        opennr=urllib.request.build_opener(urllib.request.HTTPCookieProcessor(cj), urllib.request.HTTPRedirectHandler())
        print('[+] Please Wait. Trying To Login In ')
        b_data=data.encode('ascii')
        req=opennr.open(req,b_data)
        sucess=str((req.info()))
        sucess=sucess.find('Set-Cookie')
        if (sucess==-1):
                print('\n','[+] Login Successful [+]')
                pass
        else:
                print('\n','[+] Login Failed [+]')
                input('')
                sys.exit(0)
        tokken=cook(cj) #get_cookie_from_way2sms
        print('\n [+] Tokken Received : ', tokken)
        url='http://site24.way2sms.com/smstoss.action'
        head={'User-Agent':'Mozilla/5.0 (X11; Linux x86_64; rv:31.0) Gecko/20100101 Firefox/31.0 Iceweasel/31.8.0','Refere':str('http://site24.way2sms.com/sendSMS?Token='+tokken)}
        mobile=1234567890 #Mobile_no_Thats_gonna_recive_sms
        if len(str(mobile))==10:
                pass
        else:
                print(" [*] Invalid Username")
                sys.exit(0)
        while True:
                if s!='0':
                        message=s
                        msglen=140-len(message)
                        if len(message)<140:
                                break
                        else:
                                pass
                else:
                        message='Motion Detected'
                        msglen=140-len(message)
                        if len(message)<140:
                                break
                        else:
                                pass
        print(message)
        data='ssaction=ss&Token='+tokken+'&mobile='+str(mobile)+'&message='+str(message)+'&msgLen='+str(msglen)
        req=urllib.request.Request(url, data=data, headers=head)
        print('[+] Sending SMS . Please Wait [+]')
        b_data=data.encode('ascii')
        req=opennr.open(req,b_data)
        print('\n',' [+] Task Complete Thanks For Using [+]')
        req.close()

camera = PiCamera()
pir = MotionSensor(4)
f=0

while True:
    filename = datetime.now().strftime("%Y-%m-%d_%H.%M.%S.h264")
    if pir.wait_for_motion():
        print("motion detected")
        if f==0:
                sms('0')
                f=1
        print("Video File Name",filename)
        camera.start_recording(filename)
        #print(pir.wait_for_no_motion(),pir.wait_for_motion())
    if pir.wait_for_no_motion():
        print("Motion is Not Detected,Stop Recording")
        camera.stop_recording()
        folder = pathlib.Path("/home/pi/Downloads")
        filepath = folder / filename
        target = "/Temp/"              # the target folder
        targetfile = target + filename   # the target path and file name
        d = dropbox.Dropbox('API_Key') #Replace_your_API_Key
        with filepath.open("rb") as f:
        meta = d.files_upload(f.read(), targetfile, mode=dropbox.files.WriteMode("overwrite"))
        link = d.sharing_create_shared_link(targetfile)
        url = link.url
        # link which directly downloads by replacing ?dl=0 with ?dl=1
        dl_url = re.sub(r"\?dl\=0", "?dl=1", url)
        dl_url="Follow the link "+dl_url
        sms(dl_url)