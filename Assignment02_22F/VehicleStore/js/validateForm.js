var carInfo = {
  sellerName: "",
  address: "",
  city: "",
  phone: "",
  email: "",
  make: "",
  model: "",
  year: ""
};

var carArray = [];

function validateLogin() {
  var username = (document.getElementById("username").value).trim();
  var password = (document.getElementById("password").value).trim();
  
  if (password === "pass") {
    return true;
  }
  else {
	var errorMessage = "Incorrect username or password, please try again.";
	document.getElementById("errorMessage").innerHTML = errorMessage;
    return false;
  }
}	

function validateForm() {
  carInfo.sellerName = (document.getElementById("sellerName").value).trim();
  carInfo.address = (document.getElementById("address").value).trim();
  carInfo.city = (document.getElementById("city").value).trim();
  carInfo.phone = (document.getElementById("phone").value).trim();
  carInfo.email = (document.getElementById("email").value).trim();
  carInfo.make = (document.getElementById("make").value).trim();
  carInfo.model = (document.getElementById("model").value).trim();
  carInfo.year = (document.getElementById("year").value).trim();

  console.info(carInfo);

  var errorMessage = "";

  if (carInfo.sellerName.length < 3) {
    errorMessage = "Seller Name length must be greater than 2";
  }
  else if (carInfo.address.length < 6) {
    errorMessage = "Address length must be greater than 5";
  }
  else if (carInfo.city.length < 3) {
    errorMessage = "City length must be greater than 2";
  }
  else if (!/^\d{3}-*\d{3}-*\d{4}$/.test(carInfo.phone)) {
    errorMessage = "Phone number must be in the format: 555-123-4567";
  }
  else if (!/^[a-zA-Z0-9_.-]+@*[a-zA-Z0-9_-]+\.[a-zA-Z0-9_-]+$/.test(carInfo.email)) {
    errorMessage = "Email must be in the format: abc@def.ghi";
  }
  else if (carInfo.make.length < 2) {
    errorMessage = "Make must be 2 character or longer";
  }
  else if (carInfo.model.length < 2) {
    errorMessage = "Model must be 2 character or longer";
  }
  else if (carInfo.year.length !== 4) {
    errorMessage = "Please enter a 4 character year";
  }
  else if(!/^\d+$/.test(carInfo.year)){
	errorMessage = "Year must be a number";
  }

  if (errorMessage === "") {
    if(localStorage.getItem("carArray") === null) {
      carArray = [];
    }
    else {
      carArray = JSON.parse(localStorage.getItem("carArray"));
    }
	carInfo.city = carInfo.city.slice(1); 
    carArray.push(carInfo.email);
    localStorage.setItem(carInfo.email, JSON.stringify(carInfo));
    localStorage.setItem("lastKeyEntered", carInfo.email);
    localStorage.setItem("carArray", JSON.stringify(carArray));
    return true;
  } else {
    document.getElementById("errorMessage").innerHTML = errorMessage;
    return false;
  }
}

function load() {
  var carID = localStorage.getItem("lastKeyEntered");
  var carItem = localStorage.getItem(carID);
  var carObject = JSON.parse(carItem);
  document.getElementById("displayNew").innerHTML = "<table><tr><td>Seller Name:</td><td>" + carObject.sellerName +
    "</td></tr><tr><td>Address: </td><td>" + carObject.address + "</td></tr>" +
    "<tr><td>City: </td><td>" + carObject.city + "</td></tr><tr><td>Phone: </td><td>" +
    carObject.phone + "</td>" + "</tr><tr><td>Email: </td><td>" + carObject.email + "</td></tr>" +
    "<tr><td>Your Car: </td><td><a href='https://www.jdpower.com/cars/" +
    carObject.year + "/" + carObject.make + "/" + carObject.model + "'>" + carObject.make + " " +
    carObject.model + " " + carObject.year + "</a></td></tr>" + "</table>";
}

function loadAll() {
  var carStringList = localStorage.getItem("carArray");
  var carList = JSON.parse(carStringList);
  for(var i = 0; i < carList.length; i++){
    var carItem = localStorage.getItem(carList[i]);
    var carObject = JSON.parse(carItem);
    document.getElementById("displayAll").innerHTML += "<table><tr><td>Seller Name:</td><td>" +
      carObject.sellerName + "</td></tr><tr><td>Address: </td><td>" + carObject.address + "</td></tr>" +
      "<tr><td>City: </td><td>" + carObject.city + "</td></tr><tr><td>Phone: </td><td>" + carObject.phone +
      "</td>" + "</tr><tr><td>Email: </td><td>" + carObject.email + "</td></tr>" +
      "<tr><td>Your Car: </td><td><a href='https://www.jdpower.com/cars/" +
      carObject.year + "/" + carObject.make + "/" + carObject.model + "'>" + carObject.make + " " +
      carObject.model + " " + carObject.year + "</a></td></tr>" + "</table><br>";
  }
}

function clear_all() {
  localStorage.clear();
}

function clear_one() {
  var carEmail = document.getElementById("itemEmail").value; 
  localStorage.removeItem(carEmail);
  
  var carStringList = localStorage.getItem("carArray");
  var carList = JSON.parse(carStringList);
  
  const index = carList.indexOf(carEmail);
  if (index > -1) {
    carList.splice(index, 1);
  }
  for(var i = 0; i < carList.length; i++){
  console.info(i + " - " + carList[i]);
  }
  localStorage.setItem("carArray", JSON.stringify(carList));
}