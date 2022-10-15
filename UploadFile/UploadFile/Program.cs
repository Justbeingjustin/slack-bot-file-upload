using SlackNet;
using UploadFile.Services;

const string botUserOAuthToken = "BOT_USER_OAUTH_TOKEN_HERE"; //modify this one
const string slackChannel = "#tennis";


const string fileName = "Customers";
const string fileExtension = ".xlsx";
const string title = "A Customer Report";
const string comment = "Attached is a customer's report";

var report = new CustomerService().GetReport();

var api = new SlackServiceBuilder()
    .UseApiToken(botUserOAuthToken)
    .GetApiClient();

var result = await api.Files.Upload(report, fileExtension, fileName + fileExtension, title, comment, null, new List<string>() { slackChannel });







