import {RouterModule, Routes} from '@angular/router';
import {AuthGuard} from '../../shared/_guards';
import {RepresentationListComponent} from './representation/representation-list.component';
import {RepresentationPersonListComponent} from './representation-person/representation-person-list.component';
import {EducationalCenterListComponent} from './educational-center/educational-center-list.component';
import {AdditionalUserPropListComponent} from './additional-user-prop/additional-user-prop-list.component';
import {MainCourseCategoryListComponent} from './main-course-category/main-course-category-list.component';
import {EducationalCenterMainCourseCategoryListComponent} from './educational-center-main-course-category/educational-center-main-course-category-list.component';
import {NgModule} from '@angular/core';
import {EducationalCenterCustomListComponent} from './educational-center/educational-center-custom-list.component';
import {CourseCategoryCustomListComponent} from './course-category/course-category-custom-list.component';
import {CourseCustomListComponent} from './course/course-custom-list.component';
import {CoursePlanningCustomListComponent} from './courses-planning/course-planning-custom-list.component';
import {CoursePlanningStudentListComponent} from './course-planning-student/course-planning-student-list.component';

const routes: Routes = [
    {path: 'coursePlanningStudents', component: CoursePlanningStudentListComponent, canActivate: [AuthGuard]},
    {path: 'courses', component: CourseCustomListComponent, canActivate: [AuthGuard]},
    {path: 'coursePlannings', component: CoursePlanningCustomListComponent, canActivate: [AuthGuard]},
    {path: 'representations', component: RepresentationListComponent, canActivate: [AuthGuard]},
    {path: 'representationPersons', component: RepresentationPersonListComponent, canActivate: [AuthGuard]},
    {path: 'courseCategorys', component: CourseCategoryCustomListComponent, canActivate: [AuthGuard]},
    {path: 'educationalCenters', component: EducationalCenterListComponent, canActivate: [AuthGuard]},
    {path: 'educationalCenterManagement', component: EducationalCenterCustomListComponent, canActivate: [AuthGuard]},
    {path: 'additionalUserProps', component: AdditionalUserPropListComponent, canActivate: [AuthGuard]},
    {path: 'mainCourseCategorys', component: MainCourseCategoryListComponent, canActivate: [AuthGuard]},
    {path: 'educationalCenterMainCourseCategorys', component: EducationalCenterMainCourseCategoryListComponent, canActivate: [AuthGuard]}
];

@NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule],
    }
)
export class TmsRoutingModule {

}
