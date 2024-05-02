5.Client - server

server.py:-
import socket

host = '127.0.0.1'
port = 8500

lk = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
lk.bind((host,port))
lk.listen()
client , address = lk.accept()
while True:
    data = client.recv(1024).decode()
    respone = ""
    if not data:
        break
    else:
        print("Text recieved is : "+str(data))
        print("Sending this text in upper case back to Client...")
        response = data.upper()
        client.send(response.encode())

client.close()

client.py:-

import socket

host = '127.0.0.1'
port = 8500

lk = socket.socket(socket.AF_INET,socket.SOCK_STREAM)

lk.connect((host,port))

message = input(" -> ")

while message.lower().strip() != 'end':
    lk.send(message.encode())
    data = lk.recv(1024).decode()
 
    print('Received from server: ' + data)

    message = input(" -> ")
    
response = lk.recv(1024)
