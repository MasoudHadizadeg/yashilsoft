import {RouterModule, Routes} from '@angular/router';
import {AuthGuard} from '../../shared/_guards';
import {CoursesPlanningStudentListComponent} from './courses-planning-student/courses-planning-student-list.component';
import {CourseListComponent} from './course/course-list.component';
import {CoursesPlanningListComponent} from './courses-planning/courses-planning-list.component';
import {RepresentationListComponent} from './representation/representation-list.component';
import {RepresentationPersonListComponent} from './representation-person/representation-person-list.component';
import {CourseCategoryListComponent} from './course-category/course-category-list.component';
import {EducationalCenterListComponent} from './educational-center/educational-center-list.component';
import {AdditionalUserPropListComponent} from './additional-user-prop/additional-user-prop-list.component';
import {NgModule} from '@angular/core';
import {EducationalCenterCustomListComponent} from './educational-center/educational-center-custom-list.component';

const routes: Routes = [
    {path: 'coursesPlanningStudents', component: CoursesPlanningStudentListComponent, canActivate: [AuthGuard]},
    {path: 'courses', component: CourseListComponent, canActivate: [AuthGuard]},
    {path: 'coursesPlannings', component: CoursesPlanningListComponent, canActivate: [AuthGuard]},
    {path: 'representations', component: RepresentationListComponent, canActivate: [AuthGuard]},
    {path: 'representationPersons', component: RepresentationPersonListComponent, canActivate: [AuthGuard]},
    {path: 'courseCategorys', component: CourseCategoryListComponent, canActivate: [AuthGuard]},
    {path: 'educationalCenters', component: EducationalCenterListComponent, canActivate: [AuthGuard]},
    {path: 'educationalCenterCustomList', component: EducationalCenterCustomListComponent, canActivate: [AuthGuard]},
    {path: 'additionalUserProps', component: AdditionalUserPropListComponent, canActivate: [AuthGuard]}
];

@NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule],
    }
)
export class TmsRoutingModule {

}
