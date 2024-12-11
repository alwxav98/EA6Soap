# SOAP project in C#

This project implements a SOAP web service in C# using ASP.NET. It exposes a simple service called StudentService with methods that can be consumed by SOAP clients to perform operations, such as retrieving student information.

## Instructions to run the project
### Prerequisites
1. Make sure you have Docker installed on your machine.
2. Clone this repository to your local machine:

   ```bash
   git clone  https://github.com/alwxav98/EA6Soap.git
   cd  EA6Soap
   ```

### Using Docker
1. Clone this repository to your local machine.
2. Build the Docker image with the following command:

   ```bash
   docker build -t csharp-soap .
   ```

3. Run the container with:

   ```bash
   docker run -d -p 5000:5000 --name soap-container csharp-soap
   ```
4. Access the application in your browser:
- Home page: http://localhost:8080
- API endpoint: http://localhost:8080/StudentService.asmx

## Testing the SOAP Service

### Using the CallSoapService Tab
The project includes a web interface with a tab called CallSoapService where you can directly test the SOAP functionality.

1. Navigate to the Home page: http://localhost:8080.
2. Open the CallSoapService tab in the interface.
3. Enter the necessary input values in the provided fields.
4. Submit the request to see the SOAP response displayed in the interface.

### Using SoapUI
To test the SOAP service externally, you can use SoapUI:
1. Open SoapUI and create a new SOAP project.
  - Enter the WSDL URL: http://localhost:8080/StudentService.asmx?WSDL
  - Click OK to import the WSDL.

2. Select the Operation:
  - Expand the project tree in SoapUI.
  - Navigate to BasicHttpBinding_IStudentService ➔ GetStudentInfo.

3. Send a Request:
  - Open the Request 1 under the GetStudentInfo operation.
  - Modify the SOAP body with your input. For example:

  ```bash
     <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:tem="http://tempuri.org/">
       <soapenv:Header/>
       <soapenv:Body>
         <tem:GetStudentInfo>
           <tem:name>Alexandra</tem:name>
         </tem:GetStudentInfo>
       </soapenv:Body>
     </soapenv:Envelope>
  ```
