﻿/**
 * Reloads the background color of table rows.
 */
function reloadTrBg() {
  const trList = Array.from(document.getElementsByTagName("tr"));
  const bgColors = ["var(--background)", "var(--seconday)"];
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
  const table = Array.from(document.getElementsByTagName("table"))[0];

  const trList = Array.from(table.getElementsByTagName("tr"));

  for (let i = 2; i < trList.length; i++) {
    const inputs = Array.from(trList[i].getElementsByTagName("input"));

    for (let j = 0; j < 5; j++) {
      const input = document.getElementById(`search-${j}`);
      const filter = input.value.toUpperCase().trim();
      const td = inputs[j];

      if (td != null) {
        const txtValue = td.value;
        trList[i].style.display = txtValue.toUpperCase().indexOf(filter) > -1 ? "" : "none";

        if (trList[i].style.display === "none") {
          break;
        }
      }
    }
  }

  reloadTrBg();
}

// Initial invocation of reloadTrBg()
reloadTrBg();

// Attach event listeners to search input fields
for (let i = 0; i < 5; i++) {
  document.getElementById(`search-${i}`).addEventListener("keyup", search);
  document.getElementById(`search-${i}`).addEventListener("change", search);
}