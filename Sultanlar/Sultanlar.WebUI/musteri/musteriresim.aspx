<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="musteriresim.aspx.cs" Inherits="Sultanlar.WebUI.musteri.musteriresim" %>

<%@ Register src="ucAlt.ascx" tagname="ucAlt" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Sultanlar : Müşteri Resimleri</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
    <script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <script type="text/javascript" src="js/scripts.js"></script>
    <script type="text/javascript" src="js/jquery.validate.js"></script>

</head>
<body style="margin: 0 0 0 0;background-color: #EFEEEA;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            $("input[type=submit], input[type=button]").button();
        });
    </script>

    <div style="width: 100%; font-size: 9px; font-family: Verdana; background-color: #EFEEEA; border-bottom: 1px solid #FFCFB2"">
    <table cellpadding="5" cellspacing="0">
    <tr>
    <td style="width: 800px;" valign="middle">
        <table cellpadding="0" cellspacing="0"><tr><td>
        <input type="button" value="Giriş" onclick="javascript:window.location.href='default.aspx'" /> 
        <input type="button" value="Aktiviteler" onclick="javascript:window.location.href='aktiviteler.aspx'" /> 
        <input type="button" value="H.Bedelleri" onclick="javascript:window.location.href='hizmetbedelleri.aspx'" /> 
        <input type="button" value="Anlaşmalar" onclick="javascript:window.location.href='anlasmalar.aspx'" /> 
        <input type="button" value="Siparişler" onclick="javascript:window.location.href='siparisler.aspx'" /> 
        <input type="button" value="İadeler" onclick="javascript:window.location.href='iadeler.aspx'" /> 
        <input type="button" value="Tahsilatlar" onclick="javascript:window.location.href='odemeler.aspx'" /> 
        <input type="button" value="Raporlar" onclick="javascript:window.location.href='hesapayrinti.aspx'" /> 
        <input type="button" value="Üye İşlemleri" onclick="javascript:window.location.href='uyelik.aspx'" /> 
        <input type="button" value='Mesajlar (<%= Sultanlar.DatabaseObject.Internet.GonderilenMesajlar.GetObjectCount(((Sultanlar.DatabaseObject.Internet.Musteriler)Session["Musteri"]).pkMusteriID).ToString() %>)' onclick="javascript:window.location.href='mesajlar.aspx'" /></td><td align="left"></td></tr></table>
    </td>
    <td style="width: 200px; font-family: Gisha; font-size: 12px" align="right">
        <table cellpadding="0" cellspacing="0"><tr><td><asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;</td><td><asp:ImageButton runat="server" ID="ImageButton1" OnClick="ImageButton1_Click" ImageUrl="img/ic_logout.png" /></td></tr></table>
    </td>
    </tr>
    </table>
    </div>

    <div style="width: 100%; background-color: #FFFFFF; font-size: 10px; font-family: Verdana; ">
    <div style="width: 1000px; background-position: center center; background-image: url('img/bg-logo.jpg'); background-repeat: no-repeat;">
        <div class="Baslik">
        <table cellpadding="0" cellspacing="0"><tr>
        <td><img src="img/ic_rutlar.png" /></td>
        <td>Müşteri Resim Ekleme</td>
        </tr></table>
        </div>
        <div style="padding-left: 10px">

        <table cellpadding="5" cellspacing="0">
        <tr>
        <td>
            <span style="font-size: 24px">Tür:</span>
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddlTurler" AutoPostBack="false" ForeColor="#006699" 
                Width="800px" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed; font-size: 24px"></asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td>
            <span style="font-size: 24px"><label for="txtAciklama">Açıklama</label></span>
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtAciklama" ForeColor="#006699" ClientIDMode="Static"
                Width="800px" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed; font-size: 24px"></asp:TextBox>
        </td>
        </tr>
        </table>

        <br />

        <div class="select" style="display: none">
          <label for="audioSource">Ses kaynağı: </label><select id="audioSource"></select>
        </div>

        <div class="select" style="display: none">
          <label for="audioOutput">Ses çıkışı: </label><select id="audioOutput"></select>
        </div>

        <div class="select">
          <label for="videoSource" style="font-size: 24px">Kamera seçimi: </label>
		  <select id="videoSource" style="padding: 3px 3px 3px 3px;border:1px solid #CCCCCC;background:#ededed; font-size: 24px"></select>
          <br /><br />
        </div>

        <input type="button" id="snap" value="Resim Çek" onclick="resimcek()" style="font-size: 24px" />
        <input type="button" id="btnResimGonder" value="Resmi Gönder" style="font-size: 24px" />
        <br /><br />
        <video id="video" playsinline autoplay></video>
        <canvas id="canvas"></canvas>
        <br /><br /><br />
        
            

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

start();

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
}


var image = new Image();
image.src = 'temp/31.jpg';
$(image).load(function () {
    context.drawImage(image, 0, 0);
});

var Pic = canvas.toDataURL('image/jpeg', 0.75);


$( "#btnResimGonder" ).click(function() {
    if (!$('form').valid()) {
            return false;
        }
      Pic = Pic.replace(/^data:image\/(png|jpeg);base64,/, "");
      $.ajax({
        type: 'POST',
        url: 'resim.aspx/UploadPicMerch',
        data: '{ "imageData" : "' + Pic + '", smref: "' + $('#smref').val() + '", tip: "' + $('#mtip').val() + '", tur: "' + $('select[name=ddlTurler]').val() + '", musteri: "' + $('#musteriid').val() + '", ziyaret: "' + $('#ziyaretid').val() + '", rut: "' + $('#rutid').val() + '", aciklama: "' + $('#txtAciklama').val() + '" }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (msg) {
            alert("Resim gönderildi.");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest.responseText);
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
    submitHandler: function() {
          Pic = Pic.replace(/^data:image\/(png|jpeg);base64,/, "");
          $.ajax({
            type: 'POST',
            url: 'resim.aspx/UploadPicMerch',
            data: '{ "imageData" : "' + Pic + '", smref: "' + $('#smref').val() + '", tip: "' + $('#mtip').val() + '", tur: "' + $('select[name=ddlTurler]').val() + '", musteri: "' + $('#musteriid').val() + '", ziyaret: "' + $('#ziyaretid').val() + '", rut: "' + $('#rutid').val() + '", aciklama: "' + $('#txtAciklama').val() + '" }',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (msg) {
                alert("Resim gönderildi.");
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(XMLHttpRequest.responseText);
            }
        });
        //form.submit();
    }
  });
});

</script>
            
        </div>
    </div>
    </div>
    <uc1:ucAlt ID="ucAlt1" runat="server" />
    </form>
</body>
</html>
