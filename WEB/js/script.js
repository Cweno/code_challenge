$(document).ready(function () {
    var response = null;
    var getMaxDate = function(){
        let date = new Date();
        date.setFullYear(date.getFullYear() -18);
        return date.toISOString().split('T')[0]
        // return date
    }

    var ageChecker = function(){
        let dob = $('#dateOfBirth')[0].value;
        if (dob==='' || dob===undefined || age===undefined) return false;
        $('#age')[0].value = Math.abs(new Date(Math.floor(Date.now() - new Date(dob).getTime())).getUTCFullYear() -1970)
    }

    var mainCheck = function(){
        let dob = $('#dateOfBirth')[0].value;
        let state = $('#state')[0].value;
        let age = $('#age')[0].value;
        let distribution = $('#distribution')[0].value;
        if ( dob !== '' && state !== '' && age !== '' && distribution !== '') {
            $('#getValue')[0].disabled=false; 
        }
        else{
            $('#getValue')[0].disabled=true;
            response=null 
        }

    }

    // datepicker max date => today
    // $('#dateOfBirth')[0].max = getMaxDate().toISOString().split('T')[0]
    $('#dateOfBirth')[0].max = getMaxDate()
    // get value button is diabled unless all fields have data and checks are passed
    $('#getValue')[0].disabled=true;


    // gets age from DOB 
    

    


    $('#dateOfBirth').change(function(){
        ageChecker();
        mainCheck();
    })

    $('#state').change(function(){
        mainCheck();
    })

    $('#age').change(function(){
        mainCheck();
    })

    $('#distribution').change(function(){
        mainCheck();
        if (response !== null){
            $('#premiun')[0].value = $('#distribution')[0].value*response.premium;
        }
    })

    



    $('#getValue').click(function(){
        ageChecker()
        let payload = {
            DateOfBirth : $('#dateOfBirth')[0].value,
            Age : $('#age')[0].value,
            State : $('#state')[0].value
        }

        // $.post("https://localhost:5001/premium", payload,
        //     function (data, textStatus, jqXHR) {
        //         response = data.premium;
        //         $('#annual')[0].text = 12*response;
        //         $('#monthly')[0].text = response;
                
        //     },
        // );
        response = {
            "premium": 90
        }
        $('#annual')[0].value = 12*response.premium;
        $('#monthly')[0].value = response.premium;
        $('#premiun')[0].value = response.premium*$('#distribution')[0].value;
    })

    
});