import {RouterModule, Routes} from '@angular/router';
import {AuthGuard} from '../../shared/_guards';
import {CoursesPlanningStudentListComponent} from './courses-planning-student/courses-planning-student-list.component';
import {CourseListComponent} from './course/course-list.component';
import {CoursesPlanningListComponent} from './courses-planning/courses-planning-list.component';
import {RepresentationListComponent} from './representation/representation-list.component';
import {RepresentationPersonListComponent} from './representation-person/representation-person-list.component';
import {CourseCategoryListComponent} from './course-category/course-category-list.component';
import {EducationalCenterListComponent} from './educational-center/educational-center-list.component';
import {NgModule} from '@angular/core';

const routes: Routes = [
    {path: 'coursesPlanningStudents', component: CoursesPlanningStudentListComponent, canActivate: [AuthGuard]},
    {path: 'courses', component: CourseListComponent, canActivate: [AuthGuard]},
    {path: 'coursesPlannings', component: CoursesPlanningListComponent, canActivate: [AuthGuard]},
    {path: 'representations', component: RepresentationListComponent, canActivate: [AuthGuard]},
    {path: 'representationPersons', component: RepresentationPersonListComponent, canActivate: [AuthGuard]},
    {path: 'courseCategorys', component: CourseCategoryListComponent, canActivate: [AuthGuard]},
    {path: 'educationalCenters', component: EducationalCenterListComponent, canActivate: [AuthGuard]}
];

@NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule],
    }
)
export class TmsRoutingModule {

}
