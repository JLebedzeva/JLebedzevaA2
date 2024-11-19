import requests

url = "http://localhost:5170/"
endpoint_getGreeting = "api/greetings/TimesOfDay"

response_get = requests.get(url + endpoint_getGreeting);

print (response_get.json());

