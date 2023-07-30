let name = $('.item_title > b').html();
let image = $('img.item_icon').attr('src');

let urlSplited = window.location.href.replace("https://bdocodex.com/", "").split('/');

let result = { id: urlSplited[2], name, image }
let fileName = `${urlSplited[1]}_${urlSplited[2]}_${urlSplited[0]}.json`;
let dataStr = "data:text/json;charset=utf-8," + encodeURIComponent(JSON.stringify(result));
let downloadAnchorNode = document.createElement('a');
downloadAnchorNode.setAttribute("href", dataStr);
downloadAnchorNode.setAttribute("download", fileName);
document.body.appendChild(downloadAnchorNode); // required for firefox
downloadAnchorNode.click();
downloadAnchorNode.remove();
