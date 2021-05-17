# PetController

# url: api/pet

# endpoints

---

### 1. url: api/pet

### params: none

### desc: returns all

---

### 2. url: api/pet/Filter

### params: name? type? color? minAge? maxAge?

### desc: returns all that match the optional params above

---

### 3. url: api/pet/{type}

### params: none

### desc: returns all pets that match the type entered. EXAMPLE:api/pet/cat

---

### 4. url: api/pet/color

### params: color

### desc: returns all pets that match the color

---

### 5. url: api/pet/MinAge

### params: age

### desc: returns all pets that are at least the age entered

---

### 6. url: api/pet/MaxAge

### params: age

### desc: returns all pets that are at least the age entered

---

### 7. url: api/pet/Name

### params: name

### desc: returns ONE pet that matches the name

---

### [Post]

### 8. url: api/pet/AddPet

### params: name, type, color, age

### desc: creates a new pet based on the params and adds them to the database
