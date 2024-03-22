async function reloadTable() {
  const employees = await getAllEmployees();
  populateTable(employees.value);
}

function populateTable(employees = {}) {
  const tableBody = document.getElementById("employeeTableBody");
  tableBody.innerHTML = "";
  employees.forEach((employee) => {
    const row = document.createElement("tr");
    row.innerHTML = `
            <td class="border px-4 py-2">${employee.id}</td>
            <td class="border px-4 py-2">${employee.name}</td>
            <td class="border px-4 py-2">${employee.lastName}</td>
            <td class="border px-4 py-2">${employee.rfc}</td>
            <td class="border px-4 py-2">${employee.bornDate}</td>
            <td class="border px-4 py-2">${employee.status}</td>
            <td class="border px-4 py-2"> <button class="bg-yellow-500 text-white px-4 py-2 rounded-lg w-full" onclick="edit(${employee.id})">Edit</button> </td>
            <td class="border px-4 py-2"> <button class="bg-red-500 text-white px-4 py-2 rounded-lg w-full" onclick="remove(${employee.id})">Delete</button> </td>
        `;
    tableBody.appendChild(row);
  });
}

function openModal() {
  document.getElementById("modal").style.display = "flex";
}

function openAddModal() {
  document.getElementById("modal").style.display = "flex";
  document.getElementById("employeeForm").reset();
}

function closeModal() {
  document.getElementById("modal").style.display = "none";
}

async function saveEmployee() {
  const id = document.getElementById("employeeId").value
    ? document.getElementById("employeeId").value
    : 0;
  const name = document.getElementById("name").value;
  const lastName = document.getElementById("lastName").value;
  const rfc = document.getElementById("rfc").value;
  const bornDate = document.getElementById("bornDate").value;
  const status = parseInt(document.getElementById("status").value);

  const employee = {
    id: id,
    name: name,
    lastName: lastName,
    rfc: rfc,
    bornDate: bornDate,
    status: status,
  };
  if (id) await modifyEmployee(id, employee);
  else {
    console.log(employee);
    await createEmployee(employee);
  }

  reloadTable();

  closeModal();
}

async function edit(id) {
  const employee = await getEmployeeById(id);
  // Fill form fields with employee data
  document.getElementById("employeeId").value = employee.id;
  document.getElementById("name").value = employee.name;
  document.getElementById("lastName").value = employee.lastName;
  document.getElementById("rfc").value = employee.rfc;
  document.getElementById("bornDate").value = employee.bornDate;
  document.getElementById("status").value = employee.status;
  console.log(employee.name);
  // Open modal
  openModal();
}

async function remove(id) {
  await deleteEmployee(id);

  reloadTable();
}

async function search() {
  const searchTerm = document.getElementById("searchTerm").value;
  const employees = await getAllEmployeesWhoHave(searchTerm);
  if (employees.value.length > 0) populateTable(employees.value);
  else alert("Theres no coincidences");
}

function clearSearch() {
  document.getElementById("searchTerm").value = "";
}
