<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ziyaret.aspx.cs" Inherits="Sultanlar.WebUI.merch.ziyaret" %>

<%@ Register src="ucProgress.ascx" tagname="ucProgress" tagprefix="uc1" %>
<%@ Register src="ucUst.ascx" tagname="ucUst" tagprefix="uc2" %>
<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="cache-control" content="no-cache" />
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="StyleSheet.css" />
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/jquery-validation@1.17.0/dist/jquery.validate.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="JScript.js"></script>
    <script type="text/javascript">
        function kameraAc() {
            if (!$('form').valid()) {
			window.scrollTo(0,400);
            return false;
            }
          if ($('select[name=ddlTurler]').val() == "0") {
              AndroidToast("Tür seçmeniz gerekli!");
              return;
          }

            Android.KameraAc($('#smref').val(), $('#mtip').val(), $('#musteriid').val(), $('select[name=ddlTurler]').val(), $('#rutid').val(), $('#ziyaretid').val(),  
			
                $('#txtAciklama').val().toUpperCase().replace("Ğ", "G").replace("Ü", "U").replace("Ş", "S").replace("İ", "I").replace("Ö", "O").replace("Ç", "C")

            );
        }

        function lbZiyaretSonlandirClick() {
            Goster();
            var oncekinokta;
            if (document.getElementById("txtCoords1onceki").value != "0,0") {
                oncekinokta = document.getElementById("txtCoords1onceki").value;
            }
            else {
                oncekinokta = readCookie("sulZiyBaslangic");
            }

            var p11 = parseFloat(document.getElementById("txtCoords1").value.substring(0, document.getElementById("txtCoords1").value.indexOf(",")));
            var p12 = parseFloat(document.getElementById("txtCoords1").value.substring(document.getElementById("txtCoords1").value.indexOf(",") + 1));
            var p21 = parseFloat(oncekinokta.substring(0, oncekinokta.indexOf(",")));
            var p22 = parseFloat(oncekinokta.substring(oncekinokta.indexOf(",") + 1));
            var p1 = new google.maps.LatLng(p11, p12);
            var p2 = new google.maps.LatLng(p21, p22);
            var mesafe = (google.maps.geometry.spherical.computeDistanceBetween(p1, p2)).toFixed(0).toString();
            if (isNaN(mesafe)) {
                mesafe = "-1";
            }
            document.getElementById("txtCoordsFark").value = mesafe;
            //eraseCookie("sulZiyBaslangic");
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $('#rblZiyaretSonlandirmaSebepleri').buttonset().find('label').width(260);
			//selectCam();
        });
		
		async function selectCam() {
			await sleep(2000);
			var i = 0;
			$("#videoSource option").each(function()
			{
				if (i == 1)
				{
					//alert('ziyaret başlatıldı.');
					$("#videoSource").val($(this).val());
					start();
				}
				i++;
			});
		}

		
		function sleep(ms) {
		  return new Promise(resolve => setTimeout(resolve, ms));
		}
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="form">
                <uc2:ucUst ID="ucUst" runat="server" />
                <div runat="server" id="divZiyaret">
                    <div style="font-size: 18px; padding: 10px 10px 10px 10px; vertical-align: middle">Ziyaret Ayrıntıları</div>
                    <span style="color: #D00000">Ziyaret Başlatılan Şube:</span> 
                    <asp:Label runat="server" ID="lblZiyaretSubesi"></asp:Label>
                    <br />
                    <span style="color: #D00000">Ziyaret Başlama Zamanı:</span> 
                    <asp:Label runat="server" ID="lblZiyaretBaslangic"></asp:Label>
                    <%--<br /><br /><br />
                    <asp:LinkButton runat="server" ID="lbSiparis" OnClick="lbSiparis_Click" style="color: #4E9CAF; font-size: 12px;
                        height: 12px; border: 1px solid #4E9CAF; padding: 5px; text-align: center; border-radius: 5px; 
                        font-weight: bold; text-decoration: none; margin: 5px;" OnClientClick="Goster()">Sipariş Gir</asp:LinkButton>--%>
                    <br /><br /><br />
                    <asp:LinkButton runat="server" ID="lbZiyaretIptal" OnClick="lbZiyaretIptal_Click" style="color: Red; font-size: 12px;
                        height: 12px; border: 1px solid #4E9CAF; padding: 5px; text-align: center; border-radius: 5px; 
                        font-weight: bold; text-decoration: none; margin: 5px;" OnClientClick="Goster()">Ziyareti İptal Et</asp:LinkButton>
                    <asp:Label runat="server" Width="50px"></asp:Label>
                    <asp:LinkButton runat="server" ID="lbZiyaretSonlandirUst" style="color: Green; font-size: 12px;
                        height: 12px; border: 1px solid #4E9CAF; padding: 5px; text-align: center; border-radius: 5px; 
                        font-weight: bold; text-decoration: none; margin: 5px;" OnClientClick="lbZiyaretSonlandirClick()" OnClick="ZiyaretSonlandir_Click">Ziyaret Sonlandır</asp:LinkButton>

				    <br /><br />
                </div>
                <uc1:ucProgress ID="ucProgress1" runat="server" />

        
                <table style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr><td align="center">Müşteri Resim Ekleme</td></tr>
                <tr>
                <td align="center" valign="middle" style="padding-top: 15px; padding-bottom: 15px">

                <table cellpadding="5" cellspacing="0">
                <tr>
                <td>
                    <span style="font-size: 24px">Tür:</span>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlTurler" AutoPostBack="false" ForeColor="#006699" 
                        style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed; font-size: 16px"></asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td>
                    <span style="font-size: 24px"><label for="txtAciklama">Açıklama</label></span>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtAciklama" ForeColor="#006699" ClientIDMode="Static" autocomplete="off"
                        style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed; font-size: 24px"></asp:TextBox>
                </td>
                </tr>
                </table>

                <br />

                <div style="display: none">

                <div class="select" style="display: none">
                  <label for="audioSource">Ses kaynağı: </label><select id="audioSource"></select>
                </div>

                <div class="select" style="display: none">
                  <label for="audioOutput">Ses çıkışı: </label><select id="audioOutput"></select>
                </div>

                <div class="select">
		          <select id="videoSource" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed; font-size: 24px"></select>
                  <br /><br />
                </div>

                <input type="button" id="snap" value="Resim Çek" onclick="resimcek()" style="font-size: 24px" />
                <br />
                <video id="video" playsinline autoplay style="width: 100%"></video>
                <br /><br />
                <canvas id="canvas" style="width: 100%"></canvas>
                <br /><br />
                <input type="button" id="btnResimGonder" value="Resmi Gönder" style="font-size: 24px" />

                </div>
                    
                <a class="button1" href="javascript:kameraAc()">Resim Gönder</a>
        
            

<input type="hidden" id="musteriid" name="musteriid" value='<%= ((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).pkMusteriID %>' />
<input type="hidden" id="smref" name="smref" value='<%= Session["Ziyaret"] != null ? ((Sultanlar.DatabaseObject.Internet.SatisTemsilcisiZiyaretler)Session["Ziyaret"]).intSMREF : 0 %>' />
<input type="hidden" id="mtip" name="mtip" value='<%= Session["Ziyaret"] != null ? ((Sultanlar.DatabaseObject.Internet.SatisTemsilcisiZiyaretler)Session["Ziyaret"]).strMekan[0].ToString() : "1" %>' />
<input type="hidden" id="ziyaretid" name="ziyaretid" value='<%= Session["Ziyaret"] != null ? ((Sultanlar.DatabaseObject.Internet.SatisTemsilcisiZiyaretler)Session["Ziyaret"]).pkID : 0 %>' />
<input type="hidden" id="rutid" name="rutid" value='<%= Session["Ziyaret"] != null ? ((Sultanlar.DatabaseObject.Internet.SatisTemsilcisiZiyaretler)Session["Ziyaret"]).strBARKOD : "" %>' />

<script type="text/javascript">
var videoElement = document.querySelector('video');
var audioInputSelect = document.querySelector('select#audioSource');
var audioOutputSelect = document.querySelector('select#audioOutput');
var videoSelect = document.querySelector('select#videoSource');
var selectors = [audioInputSelect, audioOutputSelect, videoSelect];

audioOutputSelect.disabled = !('sinkId' in HTMLMediaElement.prototype);

function gotDevices(deviceInfos) {
  // Handles being called several times to update labels. Preserve values.
  var values = selectors.map(function(select) {
    return select.value;
  });
  selectors.forEach(function(select) {
    while (select.firstChild) {
      select.removeChild(select.firstChild);
    }
  });
  for (var i = 0; i !== deviceInfos.length; ++i) {
    var deviceInfo = deviceInfos[i];
    var option = document.createElement('option');
    option.value = deviceInfo.deviceId;
    if (deviceInfo.kind === 'audioinput') {
      option.text = deviceInfo.label ||
          'microphone ' + (audioInputSelect.length + 1);
      audioInputSelect.appendChild(option);
    } else if (deviceInfo.kind === 'audiooutput') {
      option.text = deviceInfo.label || 'speaker ' +
          (audioOutputSelect.length + 1);
      audioOutputSelect.appendChild(option);
    } else if (deviceInfo.kind === 'videoinput') {
      option.text = deviceInfo.label || 'camera ' + (videoSelect.length + 1);
      videoSelect.appendChild(option);
    } else {
      console.log('Diğer aygıt veya kaynak: ', deviceInfo);
    }
  }
  selectors.forEach(function(select, selectorIndex) {
    if (Array.prototype.slice.call(select.childNodes).some(function(n) {
      return n.value === values[selectorIndex];
    })) {
      select.value = values[selectorIndex];
    }
  });
}

navigator.mediaDevices.enumerateDevices().then(gotDevices).catch(handleError);

// Attach audio output device to video element using device/sink ID.
function attachSinkId(element, sinkId) {
  if (typeof element.sinkId !== 'undefined') {
    element.setSinkId(sinkId)
    .then(function() {
      console.log('Ses başarıyla bağlandı: ' + sinkId);
    })
    .catch(function(error) {
      var errorMessage = error;
      if (error.name === 'SecurityError') {
        errorMessage = 'HTTPS kullanmanız gerekiyor ' +
            'aygıt: ' + error;
      }
      console.error(errorMessage);
      // Jump back to first output device in the list as it's the default.
      audioOutputSelect.selectedIndex = 0;
    });
  } else {
    console.warn('Tarayıcı desteklemiyor.');
  }
}

function changeAudioDestination() {
  var audioDestination = audioOutputSelect.value;
  attachSinkId(videoElement, audioDestination);
}

function gotStream(stream) {
  window.stream = stream; // make stream available to console
  videoElement.srcObject = stream;
  // Refresh button list in case labels have become available
  return navigator.mediaDevices.enumerateDevices();
}

function start() {
  if (window.stream) {
    window.stream.getTracks().forEach(function(track) {
      track.stop();
    });
  }
  //var audioSource = audioInputSelect.value;
  var videoSource = videoSelect.value;
  var constraints = {
    //audio: {deviceId: audioSource ? {exact: audioSource} : undefined},
    video: {deviceId: videoSource ? {exact: videoSource} : undefined, Width: 720, Height: 1280 }
  };
  navigator.mediaDevices.getUserMedia(constraints).
      then(gotStream).then(gotDevices).catch(handleError);
}

audioInputSelect.onchange = start;
audioOutputSelect.onchange = changeAudioDestination;
videoSelect.onchange = start;

//start();

function handleError(error) {
  console.log('navigator.getUserMedia error: ', error);
}


var canvas = document.getElementById('canvas');
var context = canvas.getContext('2d');


// Trigger photo take
function resimcek() {
	//var video = document.getElementById('video');
	canvas.setAttribute('Width', video.videoWidth);
	canvas.setAttribute('Height', video.videoHeight);
	context.drawImage(video, 0, 0, video.videoWidth, video.videoHeight);
    Pic = canvas.toDataURL('image/jpeg', 0.75);
    window.scrollTo(0,1200);
}


//var image = new Image();
//image.src = '31.jpg';
//$(image).load(function () {
//    context.drawImage(image, 0, 0);
//});

var Pic = canvas.toDataURL('image/jpeg', 0.75);


$( "#btnResimGonder" ).click(function() {
    if (!$('form').valid()) {
			window.scrollTo(0,400);
            return false;
        }
          if ($('select[name=ddlTurler]').val() == "0") {
              AndroidToast("Tür seçmeniz gerekli!");
              return;
          }
      Pic = Pic.replace(/^data:image\/(png|jpeg);base64,/, "");
      $.ajax({
        type: 'POST',
        url: 'resim.aspx/UploadPicMerch',
        data: '{ "imageData" : "' + Pic + '", smref: "' + $('#smref').val() + '", tip: "' + $('#mtip').val() + '", tur: "' + $('select[name=ddlTurler]').val() + '", musteri: "' + $('#musteriid').val() + '", ziyaret: "' + $('#ziyaretid').val() + '", rut: "' + $('#rutid').val() + '", aciklama: "' + $('#txtAciklama').val() + '" }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (msg) {
            AndroidToast("Resim gönderildi.");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            AndroidToast(XMLHttpRequest.responseText);
        }
    });
});


$(function() {
  $("form").validate({
    rules: {
      txtAciklama: {
				required: true
			}
    },
    messages: {
      txtAciklama: "<br><span style='font-size: 16px; color: Red'>Açıklama girilmesi zorunludur.<span>"
    },
      submitHandler: function () {
          if ($('select[name=ddlTurler]').val() == "0") {
              AndroidToast("Tür seçmeniz gerekli!");
              return;
          }
          Pic = Pic.replace(/^data:image\/(png|jpeg);base64,/, "");
          $.ajax({
            type: 'POST',
            url: 'resim.aspx/UploadPicMerch',
            data: '{ "imageData" : "' + Pic + '", smref: "' + $('#smref').val() + '", tip: "' + $('#mtip').val() + '", tur: "' + $('select[name=ddlTurler]').val() + '", musteri: "' + $('#musteriid').val() + '", ziyaret: "' + $('#ziyaretid').val() + '", rut: "' + $('#rutid').val() + '", aciklama: "' + $('#txtAciklama').val() + '" }',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (msg) {
                AndroidToast("Resim gönderildi.");
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                AndroidToast(XMLHttpRequest.responseText);
            }
        });
        //form.submit();
    }
  });
});

</script>

                </td>
                </tr>
                </table>
                <br />
                <asp:TextBox runat="server" ID="txtCoords1" Text="0,0" style="display: none"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtCoords" Text="Konum Bekleniyor..." onkeypress="return yazma(event)" style="width: 98%"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtCoordsFark" Text="0" style="display: none"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtCoords1onceki" Text="0,0" style="display: none"></asp:TextBox>
                <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDXm_Z4J-I9jrTO72lGvx1jRzTWsP6qi7Q&libraries=geometry"></script>
                <uc3:ucAlt ID="ucAlt1" runat="server" />
            </div>
        </div>

            <div style="position: absolute; width: 90%; z-index: 10;
                top: 20px" runat="server" id="divZiyaretSonlandirmaSebep" visible="false" class="suruklenebilir">
                <div style="position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;
                    filter: alpha(opacity=40); -moz-opacity: .40; opacity: .40; background-color: #000000"></div>
                <table cellpadding="5" style="width: 100%; height: 100%; background-color: #ffffff; font-family: Tahoma; font-size: 12px;
                    border: 1px solid #D1D1D1; border-radius: 5px; padding: 5px;">
                <tr>
                <td align="center" valign="middle">
                    <strong style="color: #C00000; font-size: 20px;">Ziyaret Sonlandırma Sebebi Belirleyiniz</strong>
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle" style="font-size: 16px;">
                    <asp:RadioButtonList runat="server" ID="rblZiyaretSonlandirmaSebepleri" RepeatLayout="Table"></asp:RadioButtonList>
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle" style="font-size: 10px;">
                    <asp:TextBox runat="server" ID="txtZiyaretSonlandirmaSebepAciklama" Width="98%"
                            ForeColor="#006699" BorderColor="#A3B5C9" style="padding: 3px 3px 3px 3px;"
                            BorderStyle="Solid" BorderWidth="1px" placeholder="Açıklama..." autocomplete="off"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td align="center" valign="middle">
                    <asp:LinkButton class="button" runat="server" ID="lbZiyaretSonlandirmaSebep" OnClick="lbZiyaretSonlandirmaSebep_Click">Ziyareti Sonlandır</asp:LinkButton>
                </td>
                </tr>
                </table>
            </div>
    </form>
</body>
</html>
