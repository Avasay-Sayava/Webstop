/**
 * Reloads the background color of table rows.
 */
function reloadTrBg() {
  const trList = Array.from(document.getElementsByTagName("tr"));
  const bgColors = ["rgba(0,0,0,0.1)", "rgba(0,0,0,0.2)"];
  let bgIndex = 0;

  trList.filter(tr => tr.style.display !== "none").forEach(tr => {
    tr.style.backgroundColor = bgColors[bgIndex];
    bgIndex = (bgIndex + 1) % bgColors.length;
  });
}

/**
 * Performs a search on the table rows based on user input.
 */
function search() {
  const tables = Array.from(document.getElementsByTagName("table"));

  tables.forEach(table => {
    const trList = Array.from(table.getElementsByTagName("tr"));

    for (let i = 1; i < trList.length - 1; i++) {
      const inputs = Array.from(trList[i].getElementsByTagName("input"));

      for (let j = 0; j < 5; j++) {
        const input = document.getElementById(`search-${j}`);
        const filter = input.value.toUpperCase();
        const td = inputs[j];

        if (td) {
          const txtValue = td.value;
          trList[i].style.display = txtValue.toUpperCase().indexOf(filter) > -1 ? "" : "none";

          if (trList[i].style.display === "none") {
            break;
          }
        }
      }
    }
  });

  reloadTrBg();
}

// Initial invocation of reloadTrBg()
reloadTrBg();

// Attach event listeners to search input fields
for (let i = 0; i < 5; i++) {
  document.getElementById(`search-${i}`).addEventListener("keyup", search);
  document.getElementById(`search-${i}`).addEventListener("change", search);
}