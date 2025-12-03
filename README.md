# Hair Salon Management System

Desktop application for managing hair salon appointments with role-based access.

## Team Members
- **Adam** - Backend  (Database, Business Logic)
- **Nanmi** - Frontend  (WPF UI)

## Technology Stack
- **Frontend:** WPF (Windows Presentation Foundation)
- **Backend:** C# .NET
- **Database:** SQL Server Express

## Project Structure
```
HairSalonSystem/
├── Database/              # SQL scripts
├── HairSalon.Core/        # Backend logic
└── HairSalon.WPF/         # Frontend UI
```

## Setup Instructions

### Database Setup
1. Open SQL Server Management Studio
2. Run `Database/CreateDatabase.sql`
3. Verify tables created successfully

### Backend Setup
1. Open Visual Studio
2. Create Class Library project: `HairSalon.Core`
3. Add classes in `Models/` and `Data/` folders
4. Build and test

### Frontend Setup
1. Open Visual Studio
2. Create WPF Application project: `HairSalon.WPF`
3. Add reference to `HairSalon.Core`
4. Create windows in `Views/` folder
5. Test each window individually

## Git Workflow

### Branches
- `main` - Production-ready code only
- `backend-dev` - for backend development
- `frontend-dev` - for frontend development

### Daily Workflow
```bash
# Start of day
git pull origin your-branch-name

# End of day
git add .
git commit -m "Description of changes"
git push origin your-branch-name
```

## Features

### Must-Have (MVP)
- [ ] User login (Customer/Stylist)
- [ ] Customer: Book appointments
- [ ] Customer: View appointments
- [ ] Customer: Cancel appointments
- [ ] Stylist: View schedule
- [ ] Stylist: Mark completed

### Database Tables
- User
- Customer
- Stylist
- Service
- AppointmentTypes  

## Test Credentials
```

```

## Timeline
- **Day 1-2:** Database + Backend classes
- **Day 3-4:** Frontend UI + Integration
- **Day 5-6:** Testing + Bug fixes
- **Day 7:** Documentation + Submission

## Due Date
**December 9, 2025**
```