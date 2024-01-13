 /**/
 
 var alpha2code = "br";
 var myPath = "";
 var a="";
 //var nationality = $("#nation");
 //console.log(nationality);

$.getJSON('countrycodes.json' , function(data){
   

   
  
  //var a = data.countries;
  //var b = a.filter((country) => country.Nationality === "American");
  //var c = data.countries[0].alpha_2_code;
  //var c = data.countries.filter((country) => country.Nationality === "American")[0].alpha_2_code;
  var c = data.countries.filter((country) => country.Nationality === "Portuguese")[0].alpha_2_code;
 
 
 //console.log(c);
 alpha2code = c ; 
 myPath = "https://countryflagsapi.com/png/" + alpha2code;
 document.getElementById("flagicon").src= myPath;
   

});

<img  id="flagicon" src="" alt="" class="flag float-right float-center" data-bind="attr:{src: flagurl}" />

$(document).ready(function(){
       
   $('#search').keyup(function(){
   $('#result').html('');
   var searchfield = $('#search').val();
   var expression = new RegExp(searchfield, "i");
   var baseuri = 'http://192.168.160.58/Formula1/api/drivers';
   var frase = "lol";
   
   $('#result').append('<tr><td class="align-middle" >' + frase + '</td>');
   ajaxHelper(baseuri, 'GET').done(function (data) {
       
       var records = data.List;
       $each(records,function(key , value){
           if(value.Nationality.search(expression) != -1 || value.Name.search(expression) != -1){
               $('#result').append(' <tr><td class="align-middle" >' + value.DriverId + '</td><td class="align-middle" >'+value.Name +'</td><td class="align-middle" >'+value.Nationality +'</td><td class="text-end"><a class="btn btn-default btn-light btn-sm" href:"./driverDetails.html?id="'+value.DriverId+'><i class="fa fa-address-card-o" title="Selecione para ver detalhes"></i></a></td></tr>'
                  
               )
           }
       })
       
       
       
   });
   })
})


$(document).ready(function () {
        $.ajaxSetup({ cache: false });
        $('#search').keyup(function () {
            $('#result').html('');
            $('#state').val('');
            var searchField = $('#search').val();
            var expression = new RegExp(searchField, "i");
            var baseuri = 'http://192.168.160.58/Formula1/api/drivers';
            
            $.getJSON(baseuri, function (data) {
                var records = data.List;
                $.each(records, function (key, value) {
                    if (value.Nationality.search(expression) != -1 || value.Name.search(expression) != -1) {
                        $('#result').append('<li class="list-group-item link-class"><a href="./driverDetails.html?id="'+value.DriverId+'">' + value.Name + '</a> | <span class="text-muted">' + value.DriverId + '</span></li>');
                    }
                });
            });
        });

        $('#result').on('click', 'li', function () {
            var click_text = $(this).text().split('|');
            $('#search').val($.trim(click_text[0]));
            $("#result").html('');
        });
    });

 

/*<input id="search-input" class="form-control" type="text" placeholder="Search for Drivers">*/
/*for(let i=1;i < numofDays + 1 ; i++ ){
            let text = i.toString(10);
            if(i<10){text = "0"+ text;}
            $('.days').append('<li><span class="active" id="day"'+text+'>'+text+'</span></li>');
        }*/




        function leapyear(year) {
            return (year % 100 === 0) ? (year % 400 === 0) : (year % 4 === 0);
        }

        function MonthInfo(a, b, yr) {
            var send;
            var numtxt;
            var nodays;
    
            switch (a) {
                case 1:
                    send = "January";
                    numtxt = "01";
                    nodays = 31;
    
                    break;
    
                case 2:
    
                    send = "February";
                    numtxt = "02";
                    if (leapyear(yr)){
                        nodays = 29;
                    }else{
                        nodays = 28;
                    }
                        
                    break;
    
                case 3:
                    send = "March";
                    numtxt = "03";
                    nodays = 31;
                    break;
                case 4:
                    send = "April";
                    numtxt = "04";
                    nodays = 30;
                    break;
                case 5:
                    send = "May";
                    numtxt = "05";
                    nodays = 31;
                    break;
                case 6:
                    send = "June";
                    numtxt = "06";
                    nodays = 30;
                    break;
                case 7:
                    send = "July";
                    numtxt = "07";
                    nodays = 31;
                    break;
                case 8:
                    send = "August";
                    numtxt = "08";
                    nodays = 31;
                    break;
                case 9:
                    send = "September";
                    numtxt = "09";
                    nodays = 30;
                    break;
                case 10:
                    send = "October";
                    numtxt = "10";
                    nodays = 31;
                    break;
                case 11:
                    send = "November";
                    numtxt = "11";
                    nodays = 30;
                    break;
                case 12:
                    send = "December";
                    numtxt = "12";
                    nodays = 31;
                    break;
    
                default:
                    console.log('error');
            }
            if (b == 1) { return numtxt; }
            else if (b == 2) { return send; }
            else { return nodays; }
    
    
        }


        $("#down").show();
        $("#up").show();
        $("#right").show();
        $("#left").show();
        $('span.active').removeClass('active');
        $('#result').html('');

        var YearDisp = Year.toString(10);
        var MonthDisp = MonthInfo(Month, 2, Year);
        var numofDays = MonthInfo(Month, 3 , Year);
        var arrayActives = new Array();
        if(arrayActives.length>0){
            arrayActives.forEach(element => {
            $('#day' + element).addClass("active");
           });
           console.log(arrayActives);
        }

