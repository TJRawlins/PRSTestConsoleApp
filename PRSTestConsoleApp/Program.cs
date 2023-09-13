
using PRSTestConsoleApp;
using System.Text.Json;

/*
 C# TO COMMUNICATE WITH APO
 THIS IS AN ALTERNATIVE TO CREATING AN ANGULAR COMPONENT TO COMMUNICATE WITH THE API
 CAN BE USED TO TEST THE API
 */

/* ------------------ GET -------------------- */
/*
// (1) CREATE BASE URL
const string baseurl = "http://localhost:5555";

// (2) CREATE HTTP INSTANCE
// instance of the HttpClient
HttpClient http = new HttpClient();

// (3) CREATE JSON OPTIONS INSTANCE
// json options for case sensitivity
JsonSerializerOptions joptions = new JsonSerializerOptions() {
    // make cases insensitive
    PropertyNameCaseInsensitive = true,
    // turn object into json and make camel case
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true
};

// (5) CREATE USERS CALL
// PURPOSE - make the call and return list of users by passing in http instance & json options instance
// JSONRESPONSE - allows you to return a status code from the response
// USERS - casts the response as an IEnumerable<User> so we can loop through
var jsonresponse = await GetUsersAsync(http, joptions);
var users = jsonresponse.DataReturned as IEnumerable<User>;

// (6) LOOP THROUGH AND GET USER NAMES
// PURPOSE - loop through users and print off user names in the list of users
foreach(var user in users) {
    Console.WriteLine($"{user.Firstname} {user.Lastname}");
}

// (4) GET USERS METHOD
// PURPOSE - Make API request using http request & response and return IEnumerable collection of users
// METHOD TYPE: Task<JsonResponse> from JsonResponse.cs class
// PARAMS: Pass in your http and jsonOptions instances
async Task<JsonResponse> GetUsersAsync(HttpClient http, JsonSerializerOptions jsonOptions) {
    // HTTP REQUEST INSTANCE - GET Method
    HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{baseurl}/api/users");
    // HTTP RESPONSE INSTANCE - Pass in req instance
    HttpResponseMessage res = await http.SendAsync(req);
    // ERROR TEST
    if (res.StatusCode != System.Net.HttpStatusCode.OK) Console.WriteLine($"Http ErrorCode is {res.StatusCode}");
    // STATUS CODE OK - you want a 200 returned
    Console.WriteLine($"Http StatusCode is {res.StatusCode}");
    // RESULTS INSTANCE - read result content as string of json data
    var json = await res.Content.ReadAsStringAsync();
    // DESERIALIZE JSON RESULTS: turn json string into json object of type IEnumerable<User> Collection of users (serializer turns json object into json string)
    // PARAMS: [json string instance], [type conversion], [json options instance convert lowercase json to uppercase to match c# class]
    // CASTING: cast to type (IEnumerable<User>?) collection
    var users = (IEnumerable<User>?)JsonSerializer.Deserialize(json, typeof(IEnumerable<User>), jsonOptions);
    // CHECK IF NULL
    if (users is null) {
        throw new Exception();
    }
    // RUTURN JSONRESPONSE WITH ASSINGED HTTPSTATUSCODE AND DATARETURNED PROPERTIES
    // HttpStatusCode: returns an integer of the status code
    // DataReturned: see step (5)
    return new JsonResponse() {
        HttpStatusCode = (int)res.StatusCode,
        DataReturned = users
    };
}
*/

/* ------------------ GET BY ID -------------------- */

// (1) CREATE BASE URL
const string baseurl = "http://localhost:5555";
// (2) CREATE HTTP INSTANCE
HttpClient http = new HttpClient();
// (3) CREATE JSON OPTIONS INSTANCE
JsonSerializerOptions joptions = new JsonSerializerOptions() {
    PropertyNameCaseInsensitive = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};
// (5) CREATE USERS CALL
var jsonResonse = await GetUserByIdAsync(1, http, joptions);
var user = jsonResonse.DataReturned as User;

// (6) DO STUFF
Console.WriteLine($"{user.Username} {user.Password}");

// (4) GET USER BY ID METHOD
async Task<JsonResponse> GetUserByIdAsync(int Id, HttpClient http, JsonSerializerOptions jsonOptions) {
    HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{baseurl}/api/users/{Id}");
    HttpResponseMessage res = await http.SendAsync(req);
    if (res.StatusCode != System.Net.HttpStatusCode.OK) Console.WriteLine($"Http ErrorCode: {res.StatusCode}");
    Console.WriteLine($"Http StatusCode: {res.StatusCode}");
    var json = await res.Content.ReadAsStringAsync();
    var user = (User?)JsonSerializer.Deserialize(json, typeof(User), jsonOptions);
    if (user is null) throw new Exception();
    return new JsonResponse() {
        HttpStatusCode = (int)res.StatusCode,
        DataReturned = user
    };
}


/* ------------------ PUT -------------------- */
/*
// (1) CREATE BASE URL
const string baseurl = "http://localhost:5555";

// (2) CREATE HTTP INSTANCE
HttpClient http = new HttpClient();

// (3) CREATE JSON OPTIONS INSTANCE
JsonSerializerOptions joptions = new JsonSerializerOptions() {
    // make cases insensitive
    PropertyNameCaseInsensitive = true,
    // turn object into json and make camel case
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true
};

// (5) DATA TO PASS UP
var user = new User() {
    Id = 1,
    Username = "sa", Password = "sa",
    Firstname = "System", Lastname = "Administrator",
    Phone = "911", Email = "administrator@system.com",
    IsReviewer = true, IsAdmin = true
};

await UpdateUserAsync(user, joptions);

// (4) GET USER METHOD
async Task<JsonResponse> UpdateUserAsync(User user, JsonSerializerOptions options) {
    HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Put, $"{baseurl}/api/users/{user.Id}");
    var json = JsonSerializer.Serialize<User>(user, options);
    // PARAMS: json isntanc, encoding info, type of data that we send up to server
    req.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
    // MAKE CALL AND GET RESPONSE BACK
    HttpResponseMessage res = await http.SendAsync(req);
    // GET STATUS
    Console.WriteLine($"Http StatusCode is {res.StatusCode}");
    // JSON RESPONSE INSTANCE - get from the JsonResponse class
    return new JsonResponse() {
        HttpStatusCode = (int)res.StatusCode
    };
}
*/